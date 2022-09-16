package com.myapp.searchRestaurant;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class JsonParser {

    public ArrayList<RestaurantModel>  jsonPaser(String resultJson) {

        ArrayList<RestaurantModel> restaurantModels = new ArrayList<>();
        try{
            JSONObject result_jsonObject = new JSONObject(resultJson);
            JSONArray jsonArray = new JSONArray();
            JSONObject shop_jsonObject = result_jsonObject.getJSONObject("results");
            JSONObject id_jsonObject = new JSONObject();

            jsonArray = shop_jsonObject.getJSONArray("shop");
            for(int i=0; i<=jsonArray.length(); i++) {
                id_jsonObject = jsonArray.getJSONObject(i);
                String name = id_jsonObject.getString("name");
                String access = id_jsonObject.getString("access");
                String logo_img_url = id_jsonObject.getString("logo_image");
                String time = id_jsonObject.getString("open");
                String address = id_jsonObject.getString("address");
                String feature = id_jsonObject.getString("catch");
                JSONObject photo = id_jsonObject.getJSONObject("photo");
                JSONObject mobile = photo.getJSONObject("mobile");
                String detail_img_url = mobile.getString("l");
                RestaurantModel restaurantModel = new RestaurantModel();
                restaurantModel.setName(name);
                restaurantModel.setAccess(access);
                restaurantModel.setLogo_img_url(logo_img_url);
                restaurantModel.setAddress(address);
                restaurantModel.setTime(time);
                restaurantModel.setFeature(feature);
                restaurantModel.setDetail_img_url(detail_img_url);
                restaurantModels.add(restaurantModel);
            }
            return restaurantModels;
        } catch (JSONException e) {
        }
        return restaurantModels;
    }
}
