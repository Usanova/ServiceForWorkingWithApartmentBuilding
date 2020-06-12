package com.example.chatalpha;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class MeetingListAdapter extends RecyclerView.Adapter<MeetingListAdapter.ViewHolder> {
    private ArrayList<String> StoredDataset;


    public MeetingListAdapter(ArrayList<String> dataset) {
        StoredDataset = dataset;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.chat_list_item, null);

        return new ViewHolder(view);
    }

    public void onBindViewHolder(ViewHolder viewHolder, int position) {

        RelativeLayout.LayoutParams msgContainerParams = (RelativeLayout.LayoutParams) viewHolder.messageContainer.getLayoutParams();
        RelativeLayout.LayoutParams nickNameParams = (RelativeLayout.LayoutParams) viewHolder.senderNickName.getLayoutParams();
        if(position%50==0)
        {
            msgContainerParams.setMargins(150, 0, 0, 0);
            msgContainerParams.removeRule(RelativeLayout.ALIGN_PARENT_LEFT);
            msgContainerParams.addRule(RelativeLayout.ALIGN_PARENT_RIGHT, RelativeLayout.TRUE);
            nickNameParams.height=0;
        }
        else
        {
            msgContainerParams.setMargins(0, 0, 150, 0);
            msgContainerParams.removeRule(RelativeLayout.ALIGN_PARENT_RIGHT);
            msgContainerParams.addRule(RelativeLayout.ALIGN_PARENT_LEFT, RelativeLayout.TRUE);
            nickNameParams.height=ViewGroup.LayoutParams.WRAP_CONTENT;
        }
        viewHolder.messageContainer.setLayoutParams(msgContainerParams);
        viewHolder.senderNickName.setLayoutParams(nickNameParams);

        viewHolder.itemTextView.setText(StoredDataset.get(position));
    }

    @Override
    public int getItemCount() {
        return StoredDataset.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        final TextView itemTextView;
        final RelativeLayout messageContainer;
        final TextView senderNickName;

        ViewHolder(View view) {
            super(view);
            itemTextView = (TextView) view.findViewById(R.id.item_text_view);
            messageContainer = (RelativeLayout) view.findViewById(R.id.message_container);
            senderNickName = (TextView) view.findViewById(R.id.sender_nickname);
        }
    }
}
