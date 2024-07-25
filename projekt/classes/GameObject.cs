using System;

namespace projekt
{
    class GameObject
    {
        public Visual visual;
        public Transform transform;

        public GameObject()
        {
            visual = new Visual();
            transform = new Transform();

            Program.objects.Add(this);
        }

        public GameObject(Visual visual, Transform transform)
        {
            this.visual = visual;
            this.transform = transform;

            Program.objects.Add(this);
        }
        public GameObject(Visual visual)
        {
            this.visual = visual;
            this.transform = new Transform();

            Program.objects.Add(this);
        }
        public GameObject(Transform transform)
        {
            this.visual = visual = new Visual();
            this.transform = transform;

            Program.objects.Add(this);
        }

    }
}