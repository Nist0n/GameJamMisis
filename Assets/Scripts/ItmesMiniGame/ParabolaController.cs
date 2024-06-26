using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaController : MonoBehaviour
{
    public GameObject ParabolaRoot;
    private ParabolaFly gizmo;
    private ParabolaFly parabolaFly;
    
    internal bool nextParbola = false;
    
    private float animationTime = float.MaxValue;
    
    public bool Autostart = true;
    public bool Animation = true;
    public float Speed = 1;

    void OnDrawGizmos()
    {
        if (gizmo == null)
        {
            gizmo = new ParabolaFly(ParabolaRoot.transform);
        }

        gizmo.RefreshTransforms(1f);
        if ((gizmo.Points.Length - 1) % 2 != 0)
            return;

        int accur = 50;
        Vector3 prevPos = gizmo.Points[0].position;
        for (int c = 1; c <= accur; c++)
        {
            float currTime = c * gizmo.GetDuration() / accur;
            Vector3 currPos = gizmo.GetPositionAtTime(currTime);
            float mag = (currPos - prevPos).magnitude * 2;
            Gizmos.color = new Color(mag, 0, 0, 1);
            Gizmos.DrawLine(prevPos, currPos);
            Gizmos.DrawSphere(currPos, 0.01f);
            prevPos = currPos;
        }
    }
    
    void Start()
    {

        parabolaFly = new ParabolaFly(ParabolaRoot.transform);

        if (Autostart)
        {
            RefreshTransforms(Speed);
            FollowParabola();
        }
    }
    
    void Update()
    {
        nextParbola = false;

        if (Animation && parabolaFly != null && animationTime < parabolaFly.GetDuration())
        {
            int parabolaIndexBefore;
            int parabolaIndexAfter;
            parabolaFly.GetParabolaIndexAtTime(animationTime, out parabolaIndexBefore);
            animationTime += Time.deltaTime;
            parabolaFly.GetParabolaIndexAtTime(animationTime, out parabolaIndexAfter);

            transform.position = parabolaFly.GetPositionAtTime(animationTime);

            if (parabolaIndexBefore != parabolaIndexAfter)
                nextParbola = true;
            
        }
        else if (Animation && parabolaFly != null && animationTime > parabolaFly.GetDuration())
        {
            animationTime = float.MaxValue;
            Animation = false;
        }

    }

    public void FollowParabola()
    {
        RefreshTransforms(Speed);
        animationTime = 0f;
        transform.position = parabolaFly.Points[0].position;
        Animation = true;
    }
    
    public void RefreshTransforms(float speed)
    {
        parabolaFly.RefreshTransforms(speed);
    }

    public static Vector3 ClosestPointInLine(Ray ray, Vector3 point)
    {
        return ray.origin + ray.direction * Vector3.Dot(ray.direction, point - ray.origin);
    }

    public class ParabolaFly
    {
        public Transform[] Points;
        protected Parabola3D[] parabolas;
        protected float[] partDuration;
        protected float completeDuration;

        public ParabolaFly(Transform ParabolaRoot)
        {

            List<Component> components = new List<Component>(ParabolaRoot.GetComponentsInChildren(typeof(Transform)));
            List<Transform> transforms = components.ConvertAll(c => (Transform)c);

            transforms.Remove(ParabolaRoot.transform);
            transforms.Sort(delegate (Transform a, Transform b)
            {
                return a.name.CompareTo(b.name);
            });

            Points = transforms.ToArray();

            if ((Points.Length - 1) % 2 != 0)
                throw new UnityException("ParabolaRoot needs odd number of points");
            
            if (parabolas == null || parabolas.Length < (Points.Length - 1) / 2)
            {
                parabolas = new Parabola3D[(Points.Length - 1) / 2];
                partDuration = new float[parabolas.Length];
            }

        }

        public Vector3 GetPositionAtTime(float time)
        {
            int parabolaIndex;
            float timeInParabola;
            GetParabolaIndexAtTime(time, out parabolaIndex, out timeInParabola);

            var percent = timeInParabola / partDuration[parabolaIndex];
            return parabolas[parabolaIndex].GetPositionAtLength(percent * parabolas[parabolaIndex].Length);
        }

        public void GetParabolaIndexAtTime(float time, out int parabolaIndex)
        {
            float timeInParabola;
            GetParabolaIndexAtTime(time, out parabolaIndex, out timeInParabola);
        }

        public void GetParabolaIndexAtTime(float time, out int parabolaIndex, out float timeInParabola)
        {
            timeInParabola = time;
            parabolaIndex = 0;
            
            while (parabolaIndex < parabolas.Length - 1 && partDuration[parabolaIndex] < timeInParabola)
            {
                timeInParabola -= partDuration[parabolaIndex];
                parabolaIndex++;
            }
        }

        public float GetDuration()
        {
            return completeDuration;
        }

        public void RefreshTransforms(float speed)
        {
            if (speed <= 0f)
                speed = 1f;

            if (Points != null)
            {

                completeDuration = 0;

                for (int i = 0; i < parabolas.Length; i++)
                {
                    if (parabolas[i] == null)
                        parabolas[i] = new Parabola3D();

                    parabolas[i].Set(Points[i * 2].position, Points[i * 2 + 1].position, Points[i * 2 + 2].position);
                    partDuration[i] = parabolas[i].Length / speed;
                    completeDuration += partDuration[i];
                }
            }
        }
    }

    public class Parabola3D
    {
        public float Length { get; private set; }

        public Vector3 A;
        public Vector3 B;
        public Vector3 C;

        protected Parabola2D parabola2D;
        protected Vector3 h;
        protected bool tooClose;
        
        public void Set(Vector3 A, Vector3 B, Vector3 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            refreshCurve();
        }

        public Vector3 GetPositionAtLength(float length)
        {
            var percent = length / Length;

            var x = percent * (C - A).magnitude;
            if (tooClose)
                x = percent * 2f;

            Vector3 pos;

            pos = A * (1f - percent) + C * percent + h.normalized * parabola2D.f(x);
            if (tooClose)
                pos.Set(A.x, pos.y, A.z);

            return pos;
        }

        private void refreshCurve()
        {

            if (Vector2.Distance(new Vector2(A.x, A.z), new Vector2(B.x, B.z)) < 0.1f &&
                Vector2.Distance(new Vector2(B.x, B.z), new Vector2(C.x, C.z)) < 0.1f)
                tooClose = true;
            else
                tooClose = false;

            Length = Vector3.Distance(A, B) + Vector3.Distance(B, C);

            if (!tooClose)
            {
                refreshCurveNormal();
            }
            else
            {
                refreshCurveClose();
            }
        }
        
        private void refreshCurveNormal()
        {
            Ray rl = new Ray(A, C - A);
            var v1 = ClosestPointInLine(rl, B);

            Vector2 A2d, B2d, C2d;

            A2d.x = 0f;
            A2d.y = 0f;
            B2d.x = Vector3.Distance(A, v1);
            B2d.y = Vector3.Distance(B, v1);
            C2d.x = Vector3.Distance(A, C);
            C2d.y = 0f;

            parabola2D = new Parabola2D(A2d, B2d, C2d);
            
            h = (B - v1) / Vector3.Distance(v1, B) * parabola2D.E.y;
        }

        private void refreshCurveClose()
        {
            var fac01 = (A.y <= B.y) ? 1f : -1f;
            var fac02 = (A.y <= C.y) ? 1f : -1f;

            Vector2 A2d, B2d, C2d;
            
            A2d.x = 0f;
            A2d.y = 0f;

            B2d.x = 1f;
            B2d.y = Vector3.Distance((A + C) / 2f, B) * fac01;

            C2d.x = 2f;
            C2d.y = Vector3.Distance(A, C) * fac02;

            parabola2D = new Parabola2D(A2d, B2d, C2d);
            h = Vector3.up;
        }
    }

    public class Parabola2D
    {
        public float a { get; private set; }
        public float b { get; private set; }
        public float c { get; private set; }

        public Vector2 E { get; private set; }
        public float Length { get; private set; }

        public Parabola2D(Vector2 A, Vector2 B, Vector2 C)
        {
            var divisor = ((A.x - B.x) * (A.x - C.x) * (C.x - B.x));
            if (divisor == 0f)
            {
                A.x += 0.00001f;
                B.x += 0.00002f;
                C.x += 0.00003f;
                divisor = ((A.x - B.x) * (A.x - C.x) * (C.x - B.x));
            }
            a = (A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y)) / divisor;
            b = (A.x * A.x * (B.y - C.y) + B.x * B.x * (C.y - A.y) + C.x * C.x * (A.y - B.y)) / divisor;
            c = (A.x * A.x * (B.x * C.y - C.x * B.y) + A.x * (C.x * C.x * B.y - B.x * B.x * C.y) + B.x * C.x * A.y * (B.x - C.x)) / divisor;

            b = b * -1f;

            setMetadata();
            Length = Vector2.Distance(A, C);
        }
        public float f(float x)
        {
            return a * x * x + b * x + c;
        }
        private void setMetadata()
        {
            var x = -b / (2 * a);
            E = new Vector2(x, f(x));
        }
    }
}
