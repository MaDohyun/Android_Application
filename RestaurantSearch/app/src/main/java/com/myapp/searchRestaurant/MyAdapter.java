package com.myapp.searchRestaurant;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import java.util.ArrayList;

public class MyAdapter extends RecyclerView.Adapter<MyHolder> {
    Context context;
    ArrayList<RestaurantModel> restaurantModels;

    public MyAdapter(Context c, ArrayList<RestaurantModel> restaurantModels) {
        this.context = c;
        this.restaurantModels = restaurantModels;
    }

    @NonNull
    @Override
    public MyHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View view = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.card,null);
        return new MyHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MyHolder myHolder, int i) {
        myHolder.name.setText(restaurantModels.get(i).getName());
        myHolder.access.setText(restaurantModels.get(i).getAccess());
        Glide.with(context)
                .load(restaurantModels.get(i).getLogo_img_url())
                .centerCrop()
                .into(myHolder.imageView);

        myHolder.setItemClickListener(new ItemClickListener() {
            @Override
            public void onItemClickListener(View v, int position) {

                String name = restaurantModels.get(position).getName();
                String address = restaurantModels.get(position).getAddress();
                String time = restaurantModels.get(position).getTime();
                String feature  = restaurantModels.get(position).getFeature();
                String detail_img_url = restaurantModels.get(position).getDetail_img_url();
                Intent intent = new Intent(context, DetailActivity.class);
                intent.putExtra("name",name);
                intent.putExtra("address",address);
                intent.putExtra("time",time);
                intent.putExtra("feature",feature);
                intent.putExtra("detail_img_url",detail_img_url);
                context.startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        return restaurantModels.size();
    }
}
