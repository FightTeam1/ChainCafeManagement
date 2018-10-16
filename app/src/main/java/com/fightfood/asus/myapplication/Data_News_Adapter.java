package com.fightfood.asus.myapplication;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.ArrayList;

public class Data_News_Adapter extends RecyclerView.Adapter<Data_News_Adapter.ViewHolder> {
    ArrayList<Data_News> data_news;
    Context context;

    public Data_News_Adapter(ArrayList<Data_News> data_news, Context context) {
        this.data_news = data_news;
        this.context = context;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        LayoutInflater layoutInflater = LayoutInflater.from(viewGroup.getContext());
        View itemView = layoutInflater.inflate(R.layout.recycleview_news,viewGroup,false);
        return new ViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull final ViewHolder viewHolder, int i) {
        viewHolder.img_news.setImageResource(data_news.get(i).getImage());
        viewHolder.txtCaption.setText(data_news.get(i).getCaption());
        viewHolder.txtText.setText(data_news.get(i).getText());
        viewHolder.line.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                //viewHolder.line.setBackgroundColor(ContextCompat.getColor(context,R.color.colorAccent));
                if(onItemClickedListener != null){
                    onItemClickedListener.onItemClick(viewHolder.txtCaption.getText().toString());
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return data_news.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView txtText;
        TextView txtCaption;
        ImageView img_news;
        LinearLayout line;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            txtCaption = (TextView)itemView.findViewById(R.id.txt_caption_news);
            txtText = (TextView)itemView.findViewById(R.id.txt_text_news);
            img_news = (ImageView)itemView.findViewById(R.id.img_news);
            line = (LinearLayout)itemView.findViewById(R.id.item_column_news);
        }
    }

    public interface OnItemClickedListener{
        void onItemClick(String txtCaption);
    }
    private Data_News_Adapter.OnItemClickedListener onItemClickedListener;

    public void setOnItemClickedListener(Data_News_Adapter.OnItemClickedListener onItemClickedListener){
        this.onItemClickedListener = onItemClickedListener;
    }

}
