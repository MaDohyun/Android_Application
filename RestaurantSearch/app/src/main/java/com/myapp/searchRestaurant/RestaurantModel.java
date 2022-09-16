package com.myapp.searchRestaurant;

import java.io.Serializable;

public class RestaurantModel implements Serializable {
    String name;
    String access;
    String logo_img_url;
    String address;
    String time;
    String detail_img_url;
    String feature;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAccess() {
        return access;
    }

    public void setAccess(String access) {
        this.access = access;
    }

    public String getLogo_img_url() {
        return logo_img_url;
    }

    public void setLogo_img_url(String logo_img_url) {
        this.logo_img_url = logo_img_url;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public String getDetail_img_url() {
        return detail_img_url;
    }

    public void setDetail_img_url(String detail_ima_url) {
        this.detail_img_url = detail_ima_url;
    }

    public String getFeature() {
        return feature;
    }

    public void setFeature(String feature) {
        this.feature = feature;
    }
}
