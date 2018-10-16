package com.fightfood.asus.myapplication;

import android.content.Context;

import java.util.ArrayList;

public class Data_3function {
    private int Image;
    private String Text;

    public Data_3function(int image, String text) {
        Image = image;
        Text = text;
    }
    public Data_3function(ArrayList<Data_3function> data_3functions, Context applicationContext) {

    }

    public int getImage() {
        return Image;
    }

    public String getText() {
        return Text;
    }

    public void setImage(int image) {
        Image = image;
    }

    public void setText(String text) {
        Text = text;
    }
}
