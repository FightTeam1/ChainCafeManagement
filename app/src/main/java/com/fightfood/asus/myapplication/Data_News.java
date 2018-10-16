package com.fightfood.asus.myapplication;

public class Data_News {
    private int Image;
    public String Caption;
    public String Text;

    public Data_News( int image,String caption, String text) {
        Caption = caption;
        Text = text;
        Image = image;
    }

    public int getImage() {
        return Image;
    }

    public String getCaption() {
        return Caption;
    }

    public String getText() {
        return Text;
    }

    public void setImage(int image) {
        Image = image;
    }

    public void setCaption(String caption) {
        Caption = caption;
    }

    public void setText(String text) {
        Text = text;
    }
}
