package com.myapp.searchRestaurant;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.SeekBar;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    Button btn_search;
    SeekBar seekBar;
    TextView text_range;
    int range = 1000;
    int rangeKey = 3;
    double latitude;
    double longitude;
    HttpConnector thread;
    Context context;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ActionBar actionBar = getSupportActionBar();
        actionBar.hide();

        context = this;
        Intent intent = getIntent();
        latitude = intent.getDoubleExtra("latitude", 0);
        longitude = intent.getDoubleExtra("longitude", 0);

        btn_search = findViewById(R.id.btn_search);

        seekBar = (SeekBar)findViewById(R.id.seekBarID);
        text_range = findViewById(R.id.range);
        text_range.setText("検索半径："+range+"m");

        btn_search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                thread = new HttpConnector(context);
                thread.setLatitude(Double.toString(latitude));
                thread.setLongitude(Double.toString(longitude));
                thread.setRange(Integer.toString(rangeKey));
                thread.start();
            }
        });

        seekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                switch(i){
                    case 0:
                        range = 300;
                        break;
                    case 1:
                        range = 500;
                        break;
                    case 3:
                        range = 2000;
                        break;
                    case 4:
                        range = 3000;
                        break;
                    default:
                        range = 1000;
                        break;
                }
                rangeKey = i+1;
                text_range.setText("検索半径："+range+"m");
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
            }
        });
    }
    public void MoveResultActivity(ArrayList<RestaurantModel> restaurantModels){
        Intent intent = new Intent(MainActivity.this, ResultActivity.class);
        intent.putExtra("latitude", latitude);
        intent.putExtra("longitude", longitude);
        intent.putExtra("range", range);
        intent.putExtra("restaurantModels", restaurantModels);
        startActivity(intent);
    }
}
