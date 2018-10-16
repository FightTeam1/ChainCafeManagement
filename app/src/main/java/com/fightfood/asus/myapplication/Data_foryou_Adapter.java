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

public class Data_foryou_Adapter extends RecyclerView.Adapter<Data_foryou_Adapter.ViewHolder> {

    ArrayList<DataForyou> dataForyous;
    Context context;

    public Data_foryou_Adapter(ArrayList<DataForyou> dataForyous, Context context) {
        this.dataForyous = dataForyous;
        this.context = context;
    }

    @NonNull
    @Override
    public Data_foryou_Adapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        LayoutInflater layoutInflater = LayoutInflater.from(viewGroup.getContext());
        View itemView = layoutInflater.inflate(R.layout.recycleview_foryou,viewGroup,false);
        return new ViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull final Data_foryou_Adapter.ViewHolder viewHolder, int i) {
        viewHolder.txtName.setText(dataForyous.get(i).getText());
        viewHolder.imgHinh.setImageResource(dataForyous.get(i).getImage());

        //bắt sự kiện khi click vào LinearLayout
        viewHolder.line.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                //viewHolder.line.setBackgroundColor(ContextCompat.getColor(context,R.color.colorAccent));
                if(onItemClickedListener != null){
                    onItemClickedListener.onItemClick(viewHolder.txtName.getText().toString());
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return dataForyous.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView txtName;
        ImageView imgHinh;
        LinearLayout line;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            txtName = (TextView)itemView.findViewById(R.id.text_foryou);
            imgHinh = (ImageView)itemView.findViewById(R.id.img_foryou);
            line = (LinearLayout)itemView.findViewById(R.id.item_row_foryou);
        }
    }
    public interface OnItemClickedListener{
        void onItemClick(String txtName);
    }
    private Data_foryou_Adapter.OnItemClickedListener onItemClickedListener;

    public  void setOnItemClickedListener(Data_foryou_Adapter.OnItemClickedListener onItemClickedListener){
        this.onItemClickedListener = onItemClickedListener;
    }
}
