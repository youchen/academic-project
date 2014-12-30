//
//  node.h
//  assign_05
//
//  Created by Youchen Ren on 6/14/14.
//

#ifndef assign_05_node_h
#define assign_05_node_h

#include <cstdlib>
#include <iostream>
using namespace std;

struct node{

    int coefficient;
    int exponent;
    node* Link;

    node(){
        coefficient = 0;
        exponent = 0;
        Link = NULL;
    }
    node(int c, int e){
        coefficient = c;
        exponent = e;
        Link = NULL;
    }
    int& GetC(){//?
        return coefficient;
    }
    int& GetE(){//?
        return exponent;
    }
    node* & link(){//?
        return Link;
    }
};

void print_list(node* listHead){
    while(listHead != NULL){
        cout << "coefficient: " << listHead -> GetC() <<"\n";
        cout << "exponent: " << listHead -> GetE() <<"\n";
        listHead = listHead -> link();
    }
    cout << endl;
}

node* make_int_list(int n){
    if(n <= 0) return 0;
    
    node *first, *p, *q;
    first = p = new node(1, 1);
    
    for(int i = 2; i <= n; i++){
        q = new node(i, i);
        p -> link() = q;
        p = q;
    }
    return first;
}

void print_list_rec(node* p){
    if(p == NULL) return;
    
    cout << "coefficient: " << p -> GetC() <<"\n";
    cout << "exponent: " << p->GetE() <<"\n";

    
    print_list_rec( p->link() );
}

void add_at_end(node* &first, node*r){
    node* p;
    p = first;
    
    while( p->link() ){
        p = p->link();
    }
    p->link() = r;
}

#endif
