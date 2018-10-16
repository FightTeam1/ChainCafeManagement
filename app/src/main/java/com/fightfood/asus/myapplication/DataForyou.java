package com.fightfood.asus.myapplication;
import android.content.Context;
import java.util.ArrayList;

public class DataForyou {
    private int Image;
    private String Text;

    public DataForyou(int image, String text) {
        Image = image;
        Text = text;
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
