//
//  main.cpp
//  Project_02_Color Mixer
//
//  Created by Youchen Ren on 7/20/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
//#include <GLUT/glut.h>//For XCode 5.1.1
#include <GL/glut.h>//For MSFT Visual Studio 12.0
#include <string>
#include <iostream>
using namespace std;

//The default value above the 3 Sliders.
string value_R = "127";
string value_G = "127";
string value_B = "127";
/*posR is the upper-left corner of the Red Slider in y-axis coordinates;
 posG, posB are the same for Green and Blue color Slider.
 R_component is the red color component for the bigger square;
 G_component, B_component is for Green and Blue component accordingly.
 */
int posR = 295, posG = 295, posB = 295;
double R_component = ((double)(422 - posR)) / 255.0,
G_component = ((double)(422 - posG)) / 255.0,
B_component = ((double)(422 - posB)) / 255.0;
/*
 Slider_upperEdge_yAxis_mouseDown is the Y coordinates of the upper edge of the Slider when
 the mouse left button is pushed down.
 */
int Slider_upperEdge_yAxis_mouseDown = 295;
/*
 rec_L_R meaning the "Rectangle Leftmost edge color Red" compoent, rest are the same.
 rec_R_R is for the rightmost edge, color Red component.
 */
double rec_L_R = 1.0, rec_L_G = 1.0, rec_L_B = 1.0;
double rec_R_R = 0.0, rec_R_G = 0.0, rec_R_B = 0.0;
/*
 When the left button is pushed down, the difference of
 y coordinates of the cursor on the slider and
 the y coordinates of the upper edge of the slider is
 the cursorDiff.
 When the cursor is inside the scope of the rectangle, and the left button of the mouse is pushed down,
 the difference between
 the x coordinates of the leftmost pixel column and
 the x coordinates of the cursor is
 cursorDiff_colorGather;
 */
int cursorDiff, cursorDiff_colorGather;
/*
 cur_PosR indicates the current position of the Red slider;(cur_PosG and cur_PosB are for the
 Green and Blue slider.
 cur_PosR is always keeping track of the y coordinates of the upper edge of the Red slider.
 */
int cur_PosR, cur_PosG, cur_PosB;
/*
 barR is the R parameter in glcolor3f function for Red slider;
 cur_PosG, cur_PosB are for Green and Blue slider accordingly.
 */
double barR = 1.0, barG = 1.0, barB = 1.0;
/*
 Rb is "Red Bar";
 The 3 variables below is for locking/unlocking the slider.
 Since there are only one slider allowed to be engaged when the left
 button of the mouse is pushed down and no matter where the cursor is.
 */
bool Rb = false, Gb = false, Bb = false;
/*
 This function could draw a rectangle by giving coordinates(x, y), the length and width.
 x, y indicate the coordinates of upper-left vertex of the rectangle.
 */
void draw_rectangle(int x, int y, int length, int width) {
    glBegin(GL_POLYGON);
    glVertex2i(x, y);
    glVertex2i(x + length, y);
    glVertex2i(x + length, y + width);
    glVertex2i(x, y + width);
    glEnd();
}
void display(void){
    glClear(GL_COLOR_BUFFER_BIT);
    /*
     Draw three vertical color line.
     */
    glColor3f(1, 0, 0);
    draw_rectangle(100, 167, 2, 275);
    glRasterPos2i(93, 510);
    glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, 'R');
    
    glColor3f(0, 1, 0);
    draw_rectangle(200, 167, 2, 275);
    glRasterPos2i(193, 510);
    glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, 'G');
    
    glColor3f(0, 0, 1);
    draw_rectangle(300, 167, 2, 275);
    glRasterPos2i(293, 510);
    glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, 'B');
    /*
     Draw 3 default Sliders.
     */
    glColor3f(barR, 0, 0);
    draw_rectangle(80, posR, 42, 20);
    glColor3f(0, barG, 0);
    draw_rectangle(180, posG, 42, 20);
    glColor3f(0, 0, barB);
    draw_rectangle(280, posB, 42, 20);
    
    //Put the value over the vertical color bar.
    for (int i = 80; i <= 280; i += 100) {
        if (i == 80) {
            //Color is fixed for Bitmaps when calling glRasterPos2i();
            //      therefore, glColor3f() should be ahead of the glRasterPos2i().
            glColor3f(1, 0, 0);
            glRasterPos2i(i, 100);
            void * font = GLUT_BITMAP_TIMES_ROMAN_24;
            value_R = to_string(423 - posR - 1);
            R_component = ( (double)(423 - posR - 1)) / 255.0;
            for (string::iterator i = value_R.begin(); i != value_R.end(); ++i){
                char c = *i;
                glutBitmapCharacter(font, c);
            }
        }
        else if (i == 180) {
            glColor3f(0, 1, 0);
            glRasterPos2i(i, 100);
            void * font = GLUT_BITMAP_TIMES_ROMAN_24;
            value_G = to_string(423 - posG - 1);
            G_component = ( (double)(423 - posG - 1)) / 255.0;
            for (string::iterator i = value_G.begin(); i != value_G.end(); ++i){
                char c = *i;
                glutBitmapCharacter(font, c);
            }
        }
        else if (i == 280) {
            glColor3f(0, 0, 1);
            glRasterPos2i(i, 100);
            void * font = GLUT_BITMAP_TIMES_ROMAN_24;
            value_B = to_string(423 - posB - 1);
            B_component = ( (double)(423 - posB - 1)) / 255.0;
            for (string::iterator i = value_B.begin(); i != value_B.end(); ++i){
                char c = *i;
                glutBitmapCharacter(font, c);
            }
        }
    }
    //Draw the square.
    glColor3f(R_component, G_component, B_component);
    draw_rectangle(500, 80, 300, 300);
    
    //draw the rectangle.
    for (int i = 0; i < 400; ++i) {
        glColor3f(
                  rec_L_R + (rec_R_R - rec_L_R)/400.0 * i,
                  rec_L_G + (rec_R_G - rec_L_G)/400.0 * i,
                  rec_L_B + (rec_R_B - rec_L_B)/400.0 * i
                  );
        draw_rectangle(450 + i, 450, 1, 70);
    }
    //Force the execution of all the previous OpenGL instructions.
    glFlush();
}

void keyboard(unsigned char key, int x, int y) {
    switch (key) {
        case 'l':case 'L': rec_L_R = R_component; rec_L_G = G_component; rec_L_B = B_component; break;
        case 'r':case 'R': rec_R_R = R_component; rec_R_G = G_component; rec_R_B = B_component; break;
//        case 'x':case 'X': exit(0); break;
    }
    glutPostRedisplay();
}
void mouse (int button, int state, int x, int y) {
    switch (button) {
        case GLUT_LEFT_BUTTON:
            if (state == GLUT_DOWN){
                if(
                   x >= 80 && x <= 124 && y >= cur_PosR && y <= (cur_PosR + 20)
                   ) {
                    /*
                     barR = 0.5 is for changing the color of the slider;
                     Rb = true is to locking the Red Slider.
                     */
                    cursorDiff = y - cur_PosR;
                    barR = 0.5;
                    Rb = true;
                }
                else if(
                        x >= 180 && x <= 224 && y >= cur_PosG && y <= (cur_PosG + 20)
                        ) {
                    cursorDiff = y - cur_PosG;
                    barG = 0.5;
                    Gb = true;
                }
                else if(
                        x >= 280 && x <= 324 && y >= cur_PosB && y <= (cur_PosB + 20)
                        ) {
                    cursorDiff = y - cur_PosB;
                    barB = 0.5;
                    Bb = true;
                }
                else if(
                        x >= 450 && x <= 850 &&
                        y >= 450 && y <= 520
                        ){
                    cursorDiff_colorGather = x - 450;
                    posR = (int)(422 - (rec_L_R + (rec_R_R - rec_L_R)/400.0 * cursorDiff_colorGather) * 255);
                    posG = (int)(422 - (rec_L_G + (rec_R_G - rec_L_G)/400.0 * cursorDiff_colorGather) * 255);
                    posB = (int)(422 - (rec_L_B + (rec_R_B - rec_L_B)/400.0 * cursorDiff_colorGather) * 255);
                }
                
                glutPostRedisplay();
            }
            break;
            
    }
}
void motion (int mouseX, int mouseY){
    if (mouseX >= 80 && mouseX <= 124 && Gb == false && Bb == false){
        Rb = true;
        barR = 0.5;
        Slider_upperEdge_yAxis_mouseDown = mouseY - cursorDiff;
        if (Slider_upperEdge_yAxis_mouseDown < 167) {
            posR = 167;
        }else if (Slider_upperEdge_yAxis_mouseDown > 422) {
            posR = 422;
        }
        else
            posR = Slider_upperEdge_yAxis_mouseDown;
    }
    else if (mouseX >= 180 && mouseX <= 224 && Rb == false && Bb == false){
        Gb = true;
        barG = 0.5;
        Slider_upperEdge_yAxis_mouseDown = mouseY - cursorDiff;
        if (Slider_upperEdge_yAxis_mouseDown < 167) {
            posG = 167;
        }else if (Slider_upperEdge_yAxis_mouseDown > 422) {
            posG = 422;
        }
        else
            posG = Slider_upperEdge_yAxis_mouseDown;
    }
    else if (mouseX >= 280 && mouseX <= 324 && Rb == false && Gb == false){
        Bb = true;
        barB = 0.5;
        Slider_upperEdge_yAxis_mouseDown = mouseY - cursorDiff;
        if (Slider_upperEdge_yAxis_mouseDown < 167) {
            posB = 167;
        }else if (Slider_upperEdge_yAxis_mouseDown > 422) {
            posB = 422;
        }
        else
            posB = Slider_upperEdge_yAxis_mouseDown;
    }
    glutPostRedisplay();
}

void passive (int mouseX, int mouseY) {
    cur_PosR = Slider_upperEdge_yAxis_mouseDown;
    cur_PosG = Slider_upperEdge_yAxis_mouseDown;
    cur_PosB = Slider_upperEdge_yAxis_mouseDown;
    
    barR = 1.0;
    barG = 1.0;
    barB = 1.0;
    Rb = false;
    Gb = false;
    Bb = false;
    
    glutPostRedisplay();
}

void reshape(int width, int height){
	float w_aspect = 3.0/2.0, aspect = ((float) width) / height;
	if(aspect <= w_aspect)
		glViewport(0, (height - width / w_aspect) / 2, width, width / w_aspect);
	else
		glVewport((width - height * w_aspect) / 2, 0, height * w_aspect, height );
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0.0, 899.0, 599.0, 0.0);
}

int main(int argc, char ** argv){
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(900, 600);
    glutInitWindowPosition(500, 200);
    glutCreateWindow("Youchen - Project 2 Color Mixer");
    //background color is grey.
    glClearColor(0.8, 0.8, 0.8, 0.0);
    /*
     For convinience purpose, set the coordination as
     0                899
     0
     
     
     
     
     
     599
     */
    gluOrtho2D(0.0, 899.0, 599.0, 0.0);
    
    glutKeyboardFunc(keyboard);
    glutMouseFunc(mouse);
    glutMotionFunc(motion);
    
    glutDisplayFunc(display);
    glutPassiveMotionFunc(passive);
    //glLoadIdentity();
	glutReshapeFunc(reshape);

    glutMainLoop();
}