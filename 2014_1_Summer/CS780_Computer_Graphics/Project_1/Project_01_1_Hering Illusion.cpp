//
//  main.cpp
//  Project_01_1_Hering Illusion
//
//  Created by Youchen Ren on 7/14/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0

void display(void){
   glClear(GL_COLOR_BUFFER_BIT);
   //set lines to be black color.
   glColor3f(0.0, 0.0, 0.0);
   //farestPoint is the most left point that the single line reaches.
   double farestPoint = -1000.0;
   /*
    Since the coordination space that I defined (see main method),
       the point which defines the line goes from left to right(which has 
       the positive coordination), therefore, I need to put -1 there for
       the right boundary.
    The equal distance between lines is 50.
    */
   for (double y = farestPoint; y <= (-1 * farestPoint); y += 50.0) {
       glBegin(GL_LINES);
       //The upper bound is 150; lower bound is -150.
       glVertex2i(y, 150);
       glVertex2i((-1) * y, -150);
       glEnd();
   }
   /*
    Compute for the vertical coordination for horizontal line
       by the property for similar triangles.
           1000 - 300       x
           -----------  = -----
               1000        150
    
           x = 150 * (1000 - 300 ) / 1000
   */
   double x = 150 * (farestPoint - 300) / farestPoint;
   //Horizontal line color is red and the width is 3 pixel.
   glColor3f(1.0, 0.0, 0.0);
   glLineWidth(3.0);
   //For loop is just generate 1 and -1 coeficient for the vertical
   //      coordination for horizontal line.
   for (int i = 1; i >= -1; i -= 2) {
       glBegin(GL_LINES);
       glVertex2i(-300, (150 - x) * i);
       glVertex2i(300, (150 - x) * i);
       glEnd();
   }
   //Force the execution of all the previous OpenGL instructions.
   glFlush();
}

int main(int argc, char ** argv){
   glutInit(&argc, argv);
   glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
   //the window aspect ratio is 2 / 1, set the window as 600 x 300.
   glutInitWindowSize(600, 300);
   glutInitWindowPosition(500, 300);
   glutCreateWindow("Youchen - Project 1.1 Hering Illusion");
   //background color is black.
   glClearColor(1.0, 1.0, 1.0, 0.0);
   /*
    For convinience purpose, set the coordination as
           -300        -1 0         300
       150
    
    
         0              _|_
        -1               |
    
    
      -150
    */
   gluOrtho2D(-300.0, 300.0, -150.0, 150.0);
   glutDisplayFunc(display);
   glutMainLoop();
}

