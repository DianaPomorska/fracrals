using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        static Pen pen1;
        static Graphics g;
        static Pen pen2;
       
       int Level = 5;
       float pod = 2;
        //Высота и ширина для отрисовки
        private int _width;
        private int _height;
        // Bitmap для фрактала
        private Bitmap _fractal;
        // используем для отрисовки на PictureBox
        private Graphics _graph;
        public Form1()
        {
            InitializeComponent();
            _width = pictureBox1.Width;
            _height = pictureBox1.Height;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            Level = a;
            float b = Convert.ToInt32(textBox3.Text);
            pod = b+1;
            //создаем Bitmap для треугольника
            _fractal = new Bitmap(_width, _height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fractal);
            //вершины треугольника
            PointF topPoint = new PointF(_width / 2f, 0);
            PointF leftPoint = new PointF(0, _height);
            PointF rightPoint = new PointF(_width, _height);
            //вызываем функцию отрисовки
            DrawTriangle(Level, topPoint, leftPoint, rightPoint);
            //отображаем получившийся фрактал
            pictureBox1.BackgroundImage = _fractal;

        }
        private void DrawTriangle(int level, PointF top, PointF left, PointF right)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                //рисуем фиолетовый треугольник
                _graph.FillPolygon(Brushes.White, points);
            }
            else
            {
                //вычисляем среднюю точку
                var leftMid = MidPoint(top, left); //левая сторона
                var rightMid = MidPoint(top, right); //правая сторона
                var topMid = MidPoint(left, right); // основание
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawTriangle(level - 1, top, leftMid, rightMid);
                DrawTriangle(level - 1, leftMid, left, topMid);
                DrawTriangle(level - 1, rightMid, topMid, right);
            }
        }

        //функция вычисления координат средней точки
        private PointF MidPoint(PointF p1, PointF p2)
        {
            //return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
            return new PointF(((p1.X - p2.X) / pod) + p2.X, ((p1.Y - p2.Y) / pod) + p2.Y);
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text);
            Level = a;
            float b = Convert.ToInt32(textBox2.Text);
            pod = b+1;
            //создаем Bitmap для треугольника
            _fractal = new Bitmap(_width, _height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fractal);
            //вершины треугольника
            PointF topPoint = new PointF(0, 0);
            PointF leftPoint = new PointF(0, _height);
            PointF rightPoint = new PointF(_width, _height);
            //вызываем функцию отрисовки
            DrawTriangle(Level, topPoint, leftPoint, rightPoint);
            //отображаем получившийся фрактал
            pictureBox1.BackgroundImage = _fractal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _width = pictureBox1.Width;
            _height = pictureBox1.Height;
            int a = Convert.ToInt32(textBox2.Text);
            Level = 6;
           // pod = b;
            pod = 3;
           
            // cоздаем новый объект Graphics из указанного Bitmap
           
            //вершины треугольника
           /* PointF topPoint = new PointF(_width / 2f, _height - (_width / 4));
            PointF leftPoint = new PointF(_width/4, _height);
            PointF rightPoint = new PointF(_width/4*3, _height);*/
           

          //  Fractal(Level, topPoint, leftPoint, rightPoint);
           /* PointF[] points = new PointF[3]
                {
                    topPoint, rightPoint, leftPoint
                };
             _graph.FillPolygon(Brushes.Magenta, points);*/
           //  Fractal(topPoint, leftPoint, rightPoint, Level, _graph);
         //   if (checkBox1.Checked)
          //  {
                _fractal = new Bitmap(_width, _height);
                _graph = Graphics.FromImage(_fractal);
               /* PointF topPoint = new PointF(_width / 2, _height * 2);
                PointF leftPoint = new PointF(0, _height);
                PointF rightPoint = new PointF(_width, _height);*/
                PointF topPoint = new PointF(_width / 2, _height * 2);
                PointF leftPoint = new PointF(0, _height);
                PointF rightPoint = new PointF(_width, _height);
                Fractal(leftPoint, rightPoint, topPoint, Level, _graph);
                //отображаем получившийся фрактал
                pictureBox1.BackgroundImage = _fractal;
          //  }
            /*if (checkBox2.Checked)
            {
                _fractal = new Bitmap(_width, _height);
                _graph = Graphics.FromImage(_fractal);
                PointF topPoint = new PointF(_width / 2, _height * 2);
                PointF leftPoint = new PointF(0, _height);
                PointF rightPoint = new PointF(_width, _height);
                Fractal2(leftPoint, rightPoint, topPoint, Level, _graph);
                //отображаем получившийся фрактал
                pictureBox1.BackgroundImage = _fractal;
            }*/
            
            
        }
        static int Fractal(PointF p1, PointF p2, PointF p3, int iter,Graphics _graph1)
        {
            //n -количество итераций1
            if (iter > 0)  //условие выхода из рекурсии
            {
                //средняя треть отрезка
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X)/ 3, (p1.Y + 2 * p2.Y) / 3);

                //координаты вершины угла
                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) /3, (4 * ps.Y - p3.Y) / 3);
                //рисуем его
               /* g.DrawLine(pen1, p4, pn);
                g.DrawLine(pen1, p5, pn);
                g.DrawLine(pen2, p4, p5);*/
                PointF[] points = new PointF[3]
                {
                    p4, p5, pn
                };
                _graph1.FillPolygon(Brushes.White, points);
              //  Fractal(p4, p5, pn, iter, _graph1);

                //рекурсивно вызываем функцию нужное число раз
                Fractal(p4, pn, p5, iter - 1, _graph1);
                Fractal(pn, p5, p4, iter - 1, _graph1);
                Fractal(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1, _graph1);
                Fractal(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1, _graph1);

            }
            return iter;
        }
        static int Fractal2(PointF p1, PointF p2, PointF p3, int iter, Graphics _graph1)
        {
            //n -количество итераций1
            if (iter > 0)  //условие выхода из рекурсии
            {
                //средняя треть отрезка
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                //координаты вершины угла
                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);
                //рисуем его
                /* g.DrawLine(pen1, p4, pn);
                 g.DrawLine(pen1, p5, pn);
                 g.DrawLine(pen2, p4, p5);*/
                PointF[] points = new PointF[3]
                {
                    p4, p5, pn
                };
                _graph1.FillPolygon(Brushes.White, points);
                //  Fractal(p4, p5, pn, iter, _graph1);

                //рекурсивно вызываем функцию нужное число раз
                Fractal(p4, pn, p5, iter - 1, _graph1);
                Fractal(pn, p5, p4, iter - 1, _graph1);
                Fractal(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1, _graph1);
                Fractal(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1, _graph1);

            }
            return iter;
        }
       /* private void Fractal(int level, PointF top, PointF left, PointF right)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                //рисуем фиолетовый треугольник
                _graph.FillPolygon(Brushes.Magenta, points);
            }
            else
            {
                //вычисляем среднюю точку
                var leftMid = AvrPoint(top, left); //левая сторона
                var rightMid = AvrPoint(top, right); //правая сторона
                var topMid = AvrPoint(left, right); // основание
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawTriangle(level - 1, top, leftMid, rightMid);
                DrawTriangle(level - 1, leftMid, left, topMid);
                DrawTriangle(level - 1, rightMid, topMid, right);
            }
        }
        private PointF AvrPoint(PointF p1, PointF p2)
        {
            //return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
            return new PointF((p1.X / 4 + p1.X), (p1.Y/ 4));
        }*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          //  float b = Convert.ToInt32(textBox4.Text);
           Random rnd= new Random();
           int rndnumber = rnd.Next(1,10);
           textBox3.Text = Convert.ToString(rndnumber);
        }
    }
}
