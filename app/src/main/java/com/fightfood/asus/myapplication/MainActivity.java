package com.fightfood.asus.myapplication;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.content.res.TypedArray;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.view.menu.MenuBuilder;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;
import android.support.v7.widget.Toolbar;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    RecyclerView row3function;
    RecyclerView rowforyou;
    RecyclerView columnnews;
    Toolbar toolbar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initViewData();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.menu_toolbar_main,menu);
        return super.onCreateOptionsMenu(menu);
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        switch (item.getItemId()){
            case R.id.img_notifications:
                Toast.makeText(this, "EMail", Toast.LENGTH_LONG).show();
                break;
            default:break;
        }
        return true;
    }
    public void initViewData(){
        initViewData3Function();
        initViewDataForyou();
        initViewDataNews();
        toolBar_main();
    }
    public void toolBar_main(){
        toolbar = (Toolbar)findViewById(R.id.toolbar_main);
        toolbar.setTitle("   Nguyễn Thành Công");
        toolbar.setSubtitle("   Thành viên Vàng");
        setSupportActionBar(toolbar);
        toolbar.setLogo(R.drawable.img1_foryou);
        TypedArray styledAttributes =
                getTheme().obtainStyledAttributes(new int[] { android.R.attr.actionBarSize });
        int actionBarSize  = (int) styledAttributes.getDimension(0, 0) - 20;
        styledAttributes.recycle();
        Drawable drawable= getResources().getDrawable(R.drawable.img1_foryou);
        Bitmap bitmap = ((BitmapDrawable) drawable).getBitmap();
       // bitmap = ImageConverter.getRoundedCornerBitmap(bitmap, 200);
        Drawable newdrawable = new BitmapDrawable(getResources(),
                Bitmap.createScaledBitmap(ImageConverter.getRoundedCornerBitmap(bitmap, 500000), actionBarSize,  actionBarSize , true));

        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setLogo(newdrawable);
        getSupportActionBar().setDisplayUseLogoEnabled(true);

        toolbar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               Intent intent = new Intent(MainActivity.this, Activity_Info.class);
                startActivity(intent);
            }
        });

    }
    public void initViewData3Function(){
        row3function = (RecyclerView)findViewById(R.id.recyclerview_3function);
        row3function.setHasFixedSize(true);
        LinearLayoutManager layoutManager = new LinearLayoutManager(this,LinearLayoutManager.HORIZONTAL,false);
        row3function.setLayoutManager(layoutManager);
        ArrayList<Data_3function> data_3functions = new ArrayList<>();
        data_3functions.add(new Data_3function(R.drawable.tichdiem,"Tích điểm"));
        data_3functions.add(new Data_3function(R.drawable.other,"Đặt hàng"));
        data_3functions.add(new Data_3function(R.drawable.shop,"Coupon"));
        Data_3function_Adapter data_3function_adapter = new Data_3function_Adapter(data_3functions,getApplicationContext());
        row3function.setAdapter(data_3function_adapter);
        data_3function_adapter.setOnItemClickedListener(new Data_3function_Adapter.OnItemClickedListener() {
            @Override
            public void onItemClick(String txtName) {
                Toast.makeText(MainActivity.this,txtName,Toast.LENGTH_SHORT).show();
            }
        });

    }
    public void initViewDataForyou(){
        rowforyou = (RecyclerView)findViewById(R.id.recyclerview_foryou);
        rowforyou.setHasFixedSize(true);
        LinearLayoutManager layoutManager = new LinearLayoutManager(this,LinearLayoutManager.HORIZONTAL,false);
        rowforyou.setLayoutManager(layoutManager);
        ArrayList<DataForyou> dataForyous = new ArrayList<>();
        dataForyous.add(new DataForyou(R.drawable.img1_foryou, "Đặt hàng 5 ly, nhận ưu đãi 30k mua vé xem phim"));
        dataForyous.add(new DataForyou(R.drawable.img1_foryou,"Đặt hàng 5 ly, nhận ưu đãi 30k mua vé xem phim"));
        dataForyous.add(new DataForyou(R.drawable.img1_foryou, "Đặt hàng 5 ly, nhận ưu đãi 30k mua vé xem phim"));
        dataForyous.add(new DataForyou(R.drawable.img1_foryou,"Đặt hàng 5 ly, nhận ưu đãi 30k mua vé xem phim"));
        Data_foryou_Adapter data_foryou_adapter = new Data_foryou_Adapter(dataForyous,getApplicationContext());
        rowforyou.setAdapter(data_foryou_adapter);
        data_foryou_adapter.setOnItemClickedListener(new Data_foryou_Adapter.OnItemClickedListener() {
            @Override
            public void onItemClick(String txtName) {
                Toast.makeText(MainActivity.this,txtName,Toast.LENGTH_SHORT).show();
            }
        });
    }
    public void initViewDataNews(){
        columnnews = (RecyclerView)findViewById(R.id.recyclerview_news);
        columnnews.setHasFixedSize(true);
        LinearLayoutManager layoutManager = new LinearLayoutManager(this,LinearLayoutManager.VERTICAL,false);
        columnnews.setLayoutManager(layoutManager);
        columnnews.setNestedScrollingEnabled(false);
        ArrayList<Data_News> data_news = new ArrayList<>();
        data_news.add(new Data_News(R.drawable.img1_foryou,"Bật mí 3 món quà xinh xắn tại The Coffee House đang áp dụng MUA 1 TẶNG 1 nhân dịp 20.10!","Nếu chưa biết tặng gì cho hội chị em, ghé The Coffee Houst để chộp ngay 3 món quà xinh xắn và nhận ưu đãi MUA 1 TẶNG 1 từ 15.10-20.10 nhen."));
        data_news.add(new Data_News(R.drawable.img1_foryou,"Bật mí 3 món quà xinh xắn tại The Coffee House đang áp dụng MUA 1 TẶNG 1 nhân dịp 20.10!","Nếu chưa biết tặng gì cho hội chị em, ghé The Coffee Houst để chộp ngay 3 món quà xinh xắn và nhận ưu đãi MUA 1 TẶNG 1 từ 15.10-20.10 nhen."));
        data_news.add(new Data_News(R.drawable.img1_foryou,"Bật mí 3 món quà xinh xắn tại The Coffee House đang áp dụng MUA 1 TẶNG 1 nhân dịp 20.10!","Nếu chưa biết tặng gì cho hội chị em, ghé The Coffee Houst để chộp ngay 3 món quà xinh xắn và nhận ưu đãi MUA 1 TẶNG 1 từ 15.10-20.10 nhen."));
        data_news.add(new Data_News(R.drawable.img1_foryou,"Bật mí 3 món quà xinh xắn tại The Coffee House đang áp dụng MUA 1 TẶNG 1 nhân dịp 20.10!","Nếu chưa biết tặng gì cho hội chị em, ghé The Coffee Houst để chộp ngay 3 món quà xinh xắn và nhận ưu đãi MUA 1 TẶNG 1 từ 15.10-20.10 nhen."));
        data_news.add(new Data_News(R.drawable.img1_foryou,"Bật mí 3 món quà xinh xắn tại The Coffee House đang áp dụng MUA 1 TẶNG 1 nhân dịp 20.10!","Nếu chưa biết tặng gì cho hội chị em, ghé The Coffee Houst để chộp ngay 3 món quà xinh xắn và nhận ưu đãi MUA 1 TẶNG 1 từ 15.10-20.10 nhen."));
        Data_News_Adapter data_news_adapter = new Data_News_Adapter(data_news,getApplicationContext());
        columnnews.setAdapter(data_news_adapter);
        data_news_adapter.setOnItemClickedListener(new Data_News_Adapter.OnItemClickedListener() {
            @Override
            public void onItemClick(String txtCaption) {
                Toast.makeText(MainActivity.this,txtCaption,Toast.LENGTH_SHORT).show();
            }
        });
    }
}
