//
//  main.cpp
//  assign_01
//
//  Created by Youchen Ren on 6/3/14.
/*
    Instead of using the position pointer F & R,
    I am using a private member of queue named "Num_of_elements"
    which is keeping a record of how many elements there in the queue.
 
    Therefore, in case of the default "slots" for queue is 4, if
    Num_of_elements == 4, queue is full;
    Num_of_elements == 0, queue is empty;
 
    Of course, every time using the method as following,
    Num_of_elements should be incresed or decreased accordingly.
 
    add(), Num_of_elements++;
    del(), Num_of_elements--;
 
 */
#include <iostream>
using namespace std;


class queue
{
    private:
        char* s;
        /*
            “size" is the size of the potential array.
            here the default array for implementing the queue is 4.
         */
        int F, R, size;
        int Num_of_elements;
    public:
        queue(int i=4)
        {
            s = new char[i];
            size = i;
            F = R = -1;
            Num_of_elements = 0;
        }
        
        ~queue()
        {
            delete []s;
        }
        
        bool empty()
        {
//            return F == R;
            return (Num_of_elements == 0);
        }
        
        /*	bool full()//this is for a non circular queue
         {
         if (F==-1 && R==size-1)
         return true;
         for (int i=0; i<=F; i++)
         s[i]=s[F+i+1];
         R=R-F-1;
         F=-1;
         return false;
         }*/
        
        bool full()
        {
//            if ((R+1)%5==F)
//                return true;
//            return false;
            if (Num_of_elements == 4) {
                return true;
            }
            return false;
        }
        
        
        /*	void add (char c)//non circular add
         {
         if (full())
         {
         cout << "queue is full";
         exit(1);
         }
         R++;
         s[R]=c;
         }*/
        
        void add (char c)
        {
            if (full())
            {
                cout << "Queue is full!\n";
                exit(1);
            }
            R = ( R + 1 ) % size;
            s[R] = c;
            Num_of_elements++;
        }
        
        /*	char del()// non circular
         {
         if (empty())
         {
         cout << "queue empty";
         exit(1);
         }
         F++;
         return s[F];
         }*/
        
        char del()
        {
            if (empty())
            {
                cout << "Queue is empty.\n";
                exit(1);
            }
            F = ( F + 1 ) % size;//only difference
            Num_of_elements--;
            return s[F];
        }
    
};

int main()
{
	queue q;
    
	q.add('a');
	q.add('b');
	q.add('c');
    
	cout << q.del() << q.del() << q.del() << endl;
    
	return 0;
}