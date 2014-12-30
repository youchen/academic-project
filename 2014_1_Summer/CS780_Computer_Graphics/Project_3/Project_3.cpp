//
//  main.cpp
//  Project_03_3D_Animation
//
//  Created by Youchen Ren on 8/6/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0
#include <iostream>
using namespace std;

GLfloat pos[] = {-2, 4, 5, 1},                      //light position
amb[] = {0.3, 0.3, 0.3, 1.0};               //Ambient intensity
GLfloat front_amb_diff[] = {0.4, 0.4, 0.4, 1.0};    //Front side property R G B alpha
GLfloat back_amb_diff[] = {0.4, 0.4, 0.4, 1.0};     //Back side property  R G B alpha
GLfloat front_amb_diff_Road_middle[] = {0.4, 0.4, 0.4, 1.0};
GLfloat front_amb_diff_b[] = {0.4, 0.4, 0.4, 1.0};
GLfloat front_amb_diff_o1[] = {1, 0, 0, 1.0};
GLfloat front_amb_diff_o2[] = {0, 1, 0, 1.0};
GLfloat front_amb_diff_sun[] = {1, 0.843, 0, 1.0};
GLfloat front_amb_diff_car[] = {0, 0, 1, 1.0};
GLfloat spe[] = {0.25, 0.25, 0.25, 1.0};            //Property for front and back

GLfloat theta = 0, theta_sun = 0, dt = 0.4, pauseSpeed,
axes[3][3] = {{1,0,0}, {0,1,0}, {0,0,1}};
int axis = 0;
GLdouble b = 1.1;

void earth(void) {
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff);
    glMaterialfv(GL_BACK,           GL_AMBIENT_AND_DIFFUSE, back_amb_diff);
    glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR,            spe);
    glMaterialf(GL_FRONT_AND_BACK,  GL_SHININESS,           75);
    
    glPushMatrix();                                 //Preserve CTM for object
    glTranslated(0, -20, 0);
    glRotated(theta, 1, 0, 0);//angle, x, y, z
    glutSolidSphere(20.0, 90, 90);//radius, slices, stacks.
    glPopMatrix();
}

void roadCenterLine(){
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff_Road_middle);
    glMaterialfv(GL_BACK,           GL_AMBIENT_AND_DIFFUSE, front_amb_diff_Road_middle);
    glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR,            spe);
    glMaterialf(GL_FRONT_AND_BACK,  GL_SHININESS,           75);
    for (int i = 0; i < 360; i = i + 10) {
        glPushMatrix();
        glTranslated(0, -3, 2.5);
        glRotated(theta + i, 1, 0, 0);
        glTranslated(0, -3, 0);
        glScalef(0.02, 0, 0.3);
        glutSolidCube(1);
        glPopMatrix();
    }
}

void roadSideLine(){
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff_Road_middle);
    glMaterialfv(GL_BACK,           GL_AMBIENT_AND_DIFFUSE, front_amb_diff_Road_middle);
    glMaterialf(GL_FRONT_AND_BACK,  GL_SHININESS,           75);
    for (int i = 0; i < 360; i = i + 1) {
        glPushMatrix();
        glTranslated(0.2, -3, 2.5);
        glRotated(theta + i, 1, 0, 0);
        glTranslated(0, -3, 0);
        glScalef(0.02, 0.00001, 0.3);
        glutSolidCube(1);
        glPopMatrix();
    }
    for (int i = 0; i < 360; i = i + 1) {
        glPushMatrix();
        glTranslated(-0.2, -3, 2.5);
        glRotated(theta + i, 1, 0, 0);
        glTranslated(0, -3, 0);
        glScalef(0.02, 0.00001, 0.3);
        glutSolidCube(1);
        glPopMatrix();
    }
    
}

void object_1(void) {
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff_o1);
    glMaterialfv(GL_BACK,           GL_AMBIENT_AND_DIFFUSE, back_amb_diff);
    glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR,            spe);
    glMaterialf(GL_FRONT_AND_BACK,  GL_SHININESS,           75);
    
    glPushMatrix();                                 //Preserve CTM for object
    glTranslated(0, -21.9, -0.8);
    glTranslated(0.4, 20.1, 3.7);

    glRotated(theta, 1, 0, 0);//angle, x, y, z
    
    GLUquadricObj *qobj = gluNewQuadric();
    gluLookAt(1,1,1, 0,0,0, 0,0,-1);
    qobj = gluNewQuadric();
    gluQuadricDrawStyle(qobj, GLU_FILL);
    gluCylinder(qobj,0.01,0.1,0.2,50,10);

    
    glPopMatrix();
}

void object_2(void) {
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff_o2);
    glMaterialfv(GL_BACK,           GL_AMBIENT_AND_DIFFUSE, back_amb_diff);
    glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR,            spe);
    glMaterialf(GL_FRONT_AND_BACK,  GL_SHININESS,           75);
    
    glPushMatrix();                                 //Preserve CTM for object

    glTranslated(0, -22, -0.8);
    glTranslated(-0.3, 19, 3.7);
    glRotated(theta, 1, 0, 0);//angle, x, y, z
    
    glTranslated(0, -3, 0);
    glutSolidCube(0.1);
    
    glPopMatrix();
}

void sun(void) {
    glMaterialfv(GL_FRONT,          GL_AMBIENT_AND_DIFFUSE, front_amb_diff_sun);
    glPushMatrix();
    
    glRotated(theta_sun, 0, 1, 0);//angle, x, y, z
    glTranslated(2.7, b, -0.1);
    glutSolidSphere(0.1, 90, 90);
    
    glPopMatrix();
    
}

void display(void){
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    
    
    earth();
    roadCenterLine();
    roadSideLine();
    object_1();
    object_2();
    
    sun();
    glutSwapBuffers();
}

void idle(void) {
    theta = (theta < 360)? theta + dt: dt;
    theta_sun = (theta_sun < 360)? theta_sun + 0.4: 0.4;
    glutPostRedisplay();
}

void keyboard(unsigned char key, int x, int y) {
    switch (key) {
        case ' ':
            if (dt == 0)
                dt = pauseSpeed;
            else {
                pauseSpeed = dt;
                dt = 0;
            }
            break;
        case 'h':
            if (b >= 2.8) {
                b = 2.8;
            }
            else
                b = b + 0.1;
            break;

        case 'l':
            if (b <= 1.1) {
                b = 1.1;
            }else
            b = b - 0.1;
            break;
        case 'x':
            exit(0);
            break;
    }
    glutPostRedisplay();
}

void Up_Down_key (int key, int x, int y) {
    switch (key) {
        case GLUT_KEY_UP:
            if (dt >= 3) {
                dt = 3;
            }
            else
            dt = dt + 0.1;
            break;
        case GLUT_KEY_DOWN:
            if (dt <= -1) {
                dt = -1;
            }
            else
            dt = dt - 0.1;
            break;  
    }
    glutPostRedisplay();
}

void intro(){
    cout << "Movement on Road Simulation.\n\n\n" << endl;
    cout << "Button functionality:\n " << endl;
    cout << "Arrow Up - \taccelerate. (max Speed: 3)\n";
    cout << "Arrow Down - \tdecelerate. (min Speed: -1)\n";
    cout << "Space - \t\tstop / resume.\n";
    cout << "h - \t\t\thigher the sun.\n";
    cout << "l - \t\t\tlower the sun.\n";
    cout << "x - \t\t\tterminate the program.\n";
    cout << "\n\nNote: The speed of sun movement will not be affected by the movement on road speed!" << endl;
}

int main(int argc, char ** argv) {
    glutInit(& argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(1000, 800);
    glutInitWindowPosition(0, 0);
    glutCreateWindow("Project 3 - Youchen Ren");
    glClearColor(135.0 / 255.0, 206.0 / 255.0, 235.0 / 255.0, 0.0);
    glEnable(GL_DEPTH_TEST);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    
    gluPerspective(43, 1.0, 1, 80);
    
    glLightfv(GL_LIGHT0, GL_AMBIENT, amb);
    glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glTranslated(0, 0, -5);
    glLightfv(GL_LIGHT0, GL_POSITION, pos);
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    
    glutKeyboardFunc(keyboard);
    glutSpecialFunc(Up_Down_key);
    
    glutDisplayFunc(display);
    glutIdleFunc(idle);
    intro();
    glutMainLoop();
}

