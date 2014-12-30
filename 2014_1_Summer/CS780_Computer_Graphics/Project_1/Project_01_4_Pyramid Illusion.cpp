//
//  main.cpp
//  Project_01_4_Pyramid Illusion
//
//  Created by Youchen Ren on 7/14/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0

void display(void){
    glClear(GL_COLOR_BUFFER_BIT);
    //color increment by value of 1 / 499 since the loop
    //  will iterates 500 times.
    double y, color = 0.0;
    for (y = 0.0; y <= 499.0; y += 1.0) {
        glColor3f(0.0 + color, 0.0 + color, 0.0 + color);
        glBegin(GL_POLYGON);
            glVertex2i(y, y);
            glVertex2i(999.0 - y, y);
            glVertex2i(999.0 - y, 999.0 - y);
            glVertex2i(y, 999.0 - y);
        glEnd();
    
        color += (1.0 / 499.0);
    }
    glFlush();
}

int main(int argc, char ** argv){
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(1000, 1000);
    glutInitWindowPosition(500, 500);
    //    glutInitWindowPosition(700, 400);
    glutCreateWindow("Youchen - Project 1.4 Pyramid Illusion");
    glClearColor(0.0, 0.0, 0.0, 0.0);
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




