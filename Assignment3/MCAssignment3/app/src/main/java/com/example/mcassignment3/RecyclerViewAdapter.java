package com.example.mcassignment3;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Build;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.net.URI;
import java.util.List;

public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {
    private static final int MENU_ITEM_VIEW_TYPE = 0;
    private final Context context;
    private final List<Object> mRecyclerViewItems;
    private DataObject dataObject;
    private static final int PERMISSION_STORAGE_CODE = 1000;
    public RecyclerViewAdapter(Context context, List<Object> recyclerViewItems){
        this.context = context;
        this.mRecyclerViewItems = recyclerViewItems;
    }

    public class MenuItemViewHolder extends RecyclerView.ViewHolder{
        private TextView bookTitle;
        private TextView bookAuthor;
        private TextView bookLevel;
        private TextView bookInfo;
        private ImageView bookImage;
        private Button DownloadBtn;

        MenuItemViewHolder(View view){
            super(view);
            bookTitle = (TextView) view.findViewById(R.id.book_title);
            bookAuthor = (TextView) view.findViewById(R.id.book_auth);
            bookLevel = (TextView) view.findViewById(R.id.book_level);
            bookInfo = (TextView) view.findViewById(R.id.book_info);
            bookImage = (ImageView) view.findViewById(R.id.book_img);
            DownloadBtn = (Button) view.findViewById(R.id.download_btn);
        }
    }

    @Override
    public int getItemCount() {
        return mRecyclerViewItems.size();
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View menuItemLayoutView = LayoutInflater.from(parent.getContext()).inflate(
                R.layout.container_list,parent,false);
        return new MenuItemViewHolder(menuItemLayoutView);
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        int ViewType = getItemViewType(position);
        switch (ViewType){
            case MENU_ITEM_VIEW_TYPE:
                default:
                    final MenuItemViewHolder menuItemViewHolder = (MenuItemViewHolder) holder;
                    DataObject obj = (DataObject) mRecyclerViewItems.get(position);

                    String title = obj.getTitle();
                    String Image = obj.getImage();
                    int ImageResID = context.getResources().getIdentifier(Image,"drawable",context.getPackageName());

                    menuItemViewHolder.bookTitle.setText(dataObject.getTitle());
                    menuItemViewHolder.bookAuthor.setText(dataObject.getAuthor());
                    menuItemViewHolder.bookLevel.setText(dataObject.getLevel());
                    menuItemViewHolder.bookInfo.setText(dataObject.getInfo());
                    menuItemViewHolder.bookImage.setImageResource(ImageResID);

                    menuItemViewHolder.DownloadBtn.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(dataObject.getURL()));
                            context.startActivity(intent);
                        }
                    });

        }
    }
}
