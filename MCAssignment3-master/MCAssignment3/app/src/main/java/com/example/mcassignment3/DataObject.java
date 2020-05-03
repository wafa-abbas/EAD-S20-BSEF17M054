package com.example.mcassignment3;

public class DataObject {
    private String title;
    private String author;
    private String level;
    private String info;
    private String URL;
    private String image;

    public DataObject(String title,String author,String level,String info,String image, String URL){
        this.title = title;
        this.author = author;
        this.level = level;
        this.info = info;
        this.image = image;
        this.URL = URL;
    }

    public String getTitle() {
        return title;
    }

    public String getAuthor() {
        return author;
    }

    public String getLevel() {
        return level;
    }

    public String getInfo() {
        return info;
    }

    public String getURL() {
        return URL;
    }

    public String getImage() {
        return image;
    }
}
