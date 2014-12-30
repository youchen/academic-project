//
//  main.cpp
//  Project_01_3_Café Wall Illusion
//
//  Created by Youchen Ren on 7/14/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0
#include <cmath>
using namespace std;

const double PI = 3.141592653589793;

void display(void){
    glClear(GL_COLOR_BUFFER_BIT);
    /*
     By observing the offset trend of the first black "brick" for each row,
            simply know that the implementation of "sine" function could be
            suitable model for the offset of the first black "brick" in each row
            back and force.
     "shiftAmount" is increment from 0 to positive infinity by ( PI / 4 ), by implementing
            absolute value to this trianglular function, the model could be aligned as
            the solution example showed in class.
     If the negative "sine" function value is allowed, the row of the bricks will shift to right
            after shift to left.
     */
    double shiftAmount = 0.0;
    double x, y;
    for (y = 100.0; y <= 900.0; y += 55.0) {
        //Draw the mid tone "mortar" above the bricks.
        glColor3f(0.5, 0.5, 0.5);
        glBegin(GL_POLYGON);
        glVertex2i(100, y);
        glVertex2i(899, y);
        glVertex2i(899, y + 3);
        glVertex2i(100, y + 3);
        glEnd();
        for (x = (155.0 - abs( 40 * sin(shiftAmount) ) ); x <= 850.0; x += 110.0) {
            glColor3f(0.0, 0.0, 0.0);
            glBegin(GL_POLYGON);
            glVertex2i(x, y + 3);
            glVertex2i(x + 55, y + 3);
            glVertex2i(x + 55, y + 3 + 55);
            glVertex2i(x, y + 3 + 55);
            glEnd();
        }
        shiftAmount += (PI / 4);
    }
    //Draw the LAST one of mid tone "mortar";
    glColor3f(0.5, 0.5, 0.5);
    glBegin(GL_POLYGON);
    glVertex2i(100, y);
    glVertex2i(899, y);
    glVertex2i(899, y + 3);
    glVertex2i(100, y + 3);
    glEnd();
    //Force the execution of all the previous OpenGL instructions.
    glFlush();
}

int main(int argc, char ** argv){
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(1000, 1000);
    glutInitWindowPosition(500, 500);
    glutCreateWindow("Youchen - Project 1.3 Café Wall Illusion");
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



