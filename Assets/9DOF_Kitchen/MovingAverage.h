#ifndef MOVINGAVERAGE_H
#define MOVINGAVERAGE_H

#include<Arduino.h>

class MovingAverage{
  public:
    MovingAverage(int size);

    void update(int value);
    float getAverage();
  private:
    int *readings; // list of all readings
    int index; // index of the readings
    int windowSize; 
    float total; //Sum of all readings
};

#endif