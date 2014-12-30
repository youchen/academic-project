//
//  main.cpp
//  Project_01_2_Hermann Grid Illusion
//
//  Created by Youchen Ren on 7/14/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0
void display(void){
   glClear(GL_COLOR_BUFFER_BIT);
   //Set the square color to be black.
   glColor3f(0.0, 0.0, 0.0);
   //By using for loop, we can draw the grid iteratively.
   for (int y = 100; y <= 899; y += 165) {
       for (int x = 100; x <= 899; x += 165) {
           glBegin(GL_POLYGON);
           glVertex2i(x, y);
           glVertex2i((x + 140), y);
           glVertex2i((x + 140), (y + 140));
           glVertex2i(x, (y + 140));
           glEnd();
       }
   }
   //Force the execution of all the previous OpenGL instructions.
   glFlush();
}

int main(int argc, char ** argv){
   glutInit(&argc, argv);
   glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
   glutInitWindowSize(1000, 1000);
   glutInitWindowPosition(500, 500);
   glutCreateWindow("Youchen - Project 1.2 Hermann Grid Illusion");
   //background color is white.
   glClearColor(1.0, 1.0, 1.0, 0.0);
   /*
    For convinience purpose, set the coordination as
       0                999
      0
    
    
    
    
    
    999
    */
   gluOrtho2D(0.0, 999.0, 999.0, 0.0);
   glutDisplayFunc(display);
   glutMainLoop();
}
