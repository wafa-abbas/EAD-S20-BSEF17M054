package com.example.mcassignment3;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private List<Object> booksList = new ArrayList<>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        recyclerView = (RecyclerView) findViewById(R.id.books_list);
        recyclerView.setHasFixedSize(true);

        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(this);
        recyclerView.setLayoutManager(layoutManager);

        RecyclerView.Adapter adapter = new RecyclerViewAdapter(this,booksList);
        recyclerView.setAdapter(adapter);

        addMenu();
    }

    private void addMenu(){
       try {
           String JSONDataString = readJSON();
           JSONArray menuItemArray = new JSONArray(JSONDataString);

           for(int i = 0;i < menuItemArray.length(); i++){
               JSONObject menuItemObject = menuItemArray.getJSONObject(i);
               String itemTitle = menuItemObject.getString("title");
               String itemAuthor = menuItemObject.getString("author");
               String itemLevel = menuItemObject.getString("level");
               String itemInfo = menuItemObject.getString("info");
               String image = menuItemObject.getString("cover");
               String URL = menuItemObject.getString("url");

               DataObject object = new DataObject(itemTitle,itemAuthor,itemLevel,itemInfo,image,URL);
               booksList.add(object);
           }
       }catch (IOException | JSONException exception){
           Log.e(MainActivity.class.getName(),"Unable to Parse the JSON data");
       }
    }

    private String readJSON() throws IOException{
        InputStream IStream = null;
        StringBuilder result = new StringBuilder();

        try{
            String JSONData = null;
            IStream = getAssets().open("issues.json");
            BufferedReader bufferedReader = new BufferedReader(
                    new InputStreamReader(IStream,"UTF-8"));
            while ((JSONData = bufferedReader.readLine()) != null){
                result.append(JSONData);
            }
        }finally {
            if (IStream != null) {
                IStream.close();
            }
        }
        return new String(result);
    }
}
