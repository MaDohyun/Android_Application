package com.myapp.searchRestaurant;
import android.content.Context;
import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class HttpConnector extends Thread {

    private String latitude;
    private String longitude;
    private String rangeKey;
    Context context;
    public ArrayList<RestaurantModel> restaurantModels = new ArrayList<>();
    String uri;
    public HttpConnector(Context context){
        this.context = context;
    }
    @Override
    public void run() {

        try {
            uri ="https://webservice.recruit.co.jp/hotpepper/gourmet/v1/?key=a25a01a106a69cf7&lat="+latitude+"&lng="+longitude+"&range="+rangeKey+"&order=4&count=20&format=json";
            String ur = uri.toString();
            Log.d("URL333", "url : " + uri.toString());

            URL url = new URL(ur.toString());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();

            if (conn != null) {
                conn.setConnectTimeout(10000);
                conn.setRequestMethod("GET");
                int resCode = conn.getResponseCode();
                int HTTP_OK = HttpURLConnection.HTTP_OK;
                Log.d("JsonParsing","resCode:"+resCode);
                Log.d("JsonParsing","HTTP_OK:"+HTTP_OK);
                if (resCode == HttpURLConnection.HTTP_OK) {
                    BufferedReader reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    String line = null;
                    while (true) {
                        line = reader.readLine();
                        Log.d("JsonParsing","line :"+line);
                        if (line == null) {
                            break;
                        }
                        JsonParser jsonParser = new JsonParser();
                        restaurantModels = jsonParser.jsonPaser(line);
                     }
                    reader.close();
                }
                conn.disconnect();
                ((MainActivity)context).MoveResultActivity(restaurantModels);
            }
        } catch (Exception e) {

        }
    }

    public void setLatitude(String latitude) {
        this.latitude = latitude;
    }

    public void setLongitude(String longitude) {
        this.longitude = longitude;
    }

    public ArrayList<RestaurantModel> getRestaurantModels2() {
        return restaurantModels;
    }
    public void setRange(String rangeKey) {
        this.rangeKey = rangeKey;
    }
}
