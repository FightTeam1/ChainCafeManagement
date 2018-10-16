package com.fightfood.asus.myapplication;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.ArrayList;

public class Data_3function_Adapter extends RecyclerView.Adapter<Data_3function_Adapter.ViewHolder> {

    ArrayList<Data_3function> data_3functions;
    Context context;

    public Data_3function_Adapter(ArrayList<Data_3function> data_3functions, Context context) {
        this.data_3functions = data_3functions;
        this.context = context;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        LayoutInflater layoutInflater = LayoutInflater.from(viewGroup.getContext());
        View itemView = layoutInflater.inflate(R.layout.recycleview_3function,viewGroup,false);
        return new ViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull final ViewHolder viewHolder, int i) {
        viewHolder.txtName.setText(data_3functions.get(i).getText());
        viewHolder.imgHinh.setImageResource(data_3functions.get(i).getImage());

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
        return data_3functions.size();
    }
    public class ViewHolder extends RecyclerView.ViewHolder{
        TextView txtName;
        ImageView imgHinh;
        LinearLayout line;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            txtName = (TextView)itemView.findViewById(R.id.text_3finction);
            imgHinh = (ImageView)itemView.findViewById(R.id.img_3function);
            line = (LinearLayout)itemView.findViewById(R.id.item_row_3function);
        }
    }
    public interface OnItemClickedListener{
        void onItemClick(String txtName);
    }
    private OnItemClickedListener onItemClickedListener;

    public  void setOnItemClickedListener(OnItemClickedListener onItemClickedListener){
        this.onItemClickedListener = onItemClickedListener;
    }


}
