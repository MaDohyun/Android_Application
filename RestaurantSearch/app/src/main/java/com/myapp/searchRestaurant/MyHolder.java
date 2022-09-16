package com.myapp.searchRestaurant;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

public class MyHolder extends RecyclerView.ViewHolder implements View.OnClickListener{
    ImageView imageView;
    TextView name, access;
    ItemClickListener itemClickListener;

    public MyHolder(View itemView) {
        super(itemView);
        this.imageView = itemView.findViewById(R.id.imageIv);
        this.name = itemView.findViewById(R.id.name_text);
        this.access = itemView.findViewById(R.id.access_text);

        itemView.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        this.itemClickListener.onItemClickListener(v,getLayoutPosition());

    }
    public void setItemClickListener(ItemClickListener ic){
      this.itemClickListener = ic;
    }
}
