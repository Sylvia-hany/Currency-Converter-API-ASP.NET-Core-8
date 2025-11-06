namespace AssR1WebApp.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //bubble sort
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    class ChisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //MyList & Bubble "Tigh Couple"dependency"
    //loosly couple (IOC)
    class MyList
    {
        int[] arr;
        ISort SortAl;

        public MyList(ISort _SortAl)//injection
        {
            arr = new int[10];
            SortAl = _SortAl;// new BubbleSort();
        }
        public void Order()
        {
            SortAl.Sort(arr);
        }
    }



    public class TestClass
    {

        object viewData;
        public object ViewData
        {
            get
            { return viewData;}
            set { viewData = value;}
        }

        public dynamic ViewBag
        {
            set { viewData = value; }
            get { return viewData; }
        }




        public void Add(int no1,int no2)
        {
            MyList list1 = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChisSort());








            Student std = new Student();
            object obj3 = std;//boxing
            dynamic x = 10;

            var xxxx = x;

            Student std2 = obj3 as Student;




            dynamic y = "Mohamed";
            dynamic obj = new Student();
            obj.Id = "10";
            obj = x + y;
            dynamic obj2 = new Object();

            //
        }

        public void PrintAdd()
        {
            int a = 10;
            int b = 20;
            Add(a, b);
            int x = 10;
            int y = 20;
            Add(x, y);
        }
    }

  
}
