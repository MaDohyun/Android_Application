package com.myapp.searchRestaurant;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;

public class DetailActivity extends AppCompatActivity {

    TextView nameText,addressText,timeText,featureText;
    ImageView imageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail);

        nameText = findViewById(R.id.detail_nameText);
        addressText = findViewById(R.id.detial_addressText);
        timeText = findViewById(R.id.detail_timeText);
        featureText = findViewById(R.id.detail_featureText);
        imageView = findViewById(R.id.detail_Image);

        Intent intent = getIntent();
        String detail_name = intent.getStringExtra("name");
        String detail_address = intent.getStringExtra("address");
        String detail_time = intent.getStringExtra("time");
        String detail_feature = intent.getStringExtra("feature");
        String detail_img_url = intent.getStringExtra("detail_img_url");

        Glide.with(this)
                .load(detail_img_url)
                .centerCrop()
                .into(imageView);

        nameText.setText(detail_name);
        addressText.setText("住所："+detail_address);
        timeText.setText("営業時間："+detail_time);
        if(detail_feature.length() != 0) {
            featureText.setText("特徴：" + detail_feature);
        }
    }
}