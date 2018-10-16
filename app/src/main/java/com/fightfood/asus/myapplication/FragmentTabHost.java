package com.fightfood.asus.myapplication;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.TabHost;


public class FragmentTabHost extends AppCompatActivity {
    public TabHost mTabHost;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_tabhost);
       // mTabHost = (TabHost) findViewById(android.R.id.tabhost);
       // mTabHost.setup(this,getSupportFragmentManager(),R.id.realtabcontent);
      //  mTabHost.setOnTabChangedListener(onTab)



    }
}
