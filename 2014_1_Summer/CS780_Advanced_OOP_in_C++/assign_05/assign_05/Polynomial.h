//
//  Polynomial.h
//  assign_05
//
//  Created by Youchen Ren on 6/14/14.
//

#include "node.h"
#include <string>
#include <iostream>
#include <sstream>
#ifndef assign_05_Polynomial_h
#define assign_05_Polynomial_h


class Polynomial{
private:
    node* head;
    int length;
    string str;

public:
    Polynomial(){
        head = new node();
        length = 0;
    }
    Polynomial(string equation){
        string val_1, val_2;
        head = new node();
        istringstream trim(equation);
        
        while (trim >> val_1 >> val_2) {
            append(strtoint(val_1), strtoint(val_2));
        }
        
    }
    //copy constructor.
    Polynomial(const Polynomial& src){
        head = new node();
        node *NodeCopy = src.head -> Link;
        
        while (NodeCopy != NULL) {
            append( NodeCopy -> coefficient, NodeCopy -> exponent);
            NodeCopy = NodeCopy -> Link;
        }
    }
    
    ~Polynomial(){
        node *deleteThis = head;
        node *copyNode;
        
        while (deleteThis != NULL) {
            copyNode = deleteThis -> Link;
            delete deleteThis;
            deleteThis = copyNode;
        }
    }
    
    Polynomial operator+(Polynomial& p2){
        Polynomial ans;
        
        node *x = head -> Link;
        node *y = p2.head -> Link;
        
        while (x != NULL) {
            ans.append(x -> coefficient, x -> exponent);
            x = x -> Link;
        }
        while (y != NULL) {
            ans.append( y -> coefficient, y -> exponent);
            y = y -> Link;
        }
        return ans;
    }
    Polynomial operator-(Polynomial &p2){
        Polynomial ans;
        
        node *x = head -> Link;
        node *y = p2.head -> Link;
        
        while (x != NULL) {
            ans.append(x -> coefficient, x -> exponent);
            x = x -> Link;
        }
        while (y != NULL) {
            ans.append( (-1)*y -> coefficient, y -> exponent);
            y = y -> Link;
        }
        return ans;
        
    }
    Polynomial operator*(Polynomial &p2){
        Polynomial ans;
        node *x = head -> Link;
        node *y;
        
        while (x != NULL) {
            y = p2.head -> Link;
            while (y != NULL) {
                ans.append( (x -> coefficient) * (y -> coefficient), x -> exponent + y -> exponent);
                y = y -> Link;
            }
            x = x ->Link;
        }
        return ans;
    }
    Polynomial operator=(const Polynomial &p2){
        if (this == &p2) {
            return *this;
        }
        node *deleteThis = head;
        node *copyNode = deleteThis -> Link;
        
        while (deleteThis != NULL) {
            delete deleteThis;
            deleteThis = copyNode;
            copyNode = deleteThis -> Link;
        }
        
        head = new node();
        node *x = p2.head -> Link;
        
        while (x != NULL) {
            append(x -> coefficient, x -> exponent);
            x = x -> Link;
        }
        return *this;
    }
    void append(int c, int e){
        if (c == 0) {
            return;
        }
        
        node *temp = head;
        while ( temp -> Link != NULL) {
            if (e == temp -> Link -> exponent) {
                temp -> Link -> coefficient += c;
                return;
            }
            if (e > temp->Link -> exponent) {
                node *temp2 = new node(c, e);
                temp2 -> Link = temp -> Link;
                temp -> Link = temp2;
                return;
            }
            temp = temp -> Link;
        }
        
        if (temp -> Link == NULL) {
            temp -> Link = new node(c, e);
        }
        
    }
    friend ostream& operator<<(ostream& os, Polynomial p2){
        node* temp = p2.head -> Link;
        
        if(temp == NULL){
            os << "0 0";
        }
        
        while(temp != NULL){
            if( temp -> coefficient != 0){
                os << temp -> coefficient << " " << temp -> exponent << " ";
            }
            temp = temp -> Link;
        }
        os << endl;
        return os;
    }
    
    int strtoint(string str){
        int integer;
        istringstream(str) >> integer;
        return integer;
    }
    
};

#endif
