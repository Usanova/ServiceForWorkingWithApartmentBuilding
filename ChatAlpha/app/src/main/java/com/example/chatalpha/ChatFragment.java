package com.example.chatalpha;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.microsoft.signalr.HubConnection;
import com.microsoft.signalr.HubConnectionBuilder;
import com.microsoft.signalr.HubConnectionState;

import java.util.ArrayList;

public class ChatFragment extends Fragment {

    RecyclerView messageList;
    RecyclerView.Adapter messageListAdadpter;
    RecyclerView.LayoutManager messageListLayoutManager;
    ArrayList<String> dataset = new ArrayList<String>();

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_chat, container,false);

        for(int i=0; i<100; i++)
            dataset.add(String.valueOf(i));

        messageList = (RecyclerView) rootView.findViewById(R.id.rvMessageList);

        messageListLayoutManager = new LinearLayoutManager(getActivity());
        messageList.setLayoutManager(messageListLayoutManager);

        messageListAdadpter = new MeetingListAdapter(dataset);

        messageListAdadpter.registerAdapterDataObserver(new RecyclerView.AdapterDataObserver() {
            @Override
            public void onItemRangeInserted(int positionStart, int itemCount) {
                Log.d("Added", String.valueOf(itemCount));
                messageList.scrollToPosition(dataset.size()-1);
            }
        });
        messageList.setAdapter(messageListAdadpter);

        dataset.add("it's a long message for wrapping check!!!!!! please, check more lines!!!!!");


//        messageList.addOnLayoutChangeListener(new View.OnLayoutChangeListener() {
//            @Override
//            public void onLayoutChange(View v,
//                                       int left, int top, int right, final int bottom,
//                                       int oldLeft, int oldTop, int oldRight, final int oldBottom) {
//
//                final int dy = oldBottom - bottom;
//                if (dy < 0 && ((LinearLayoutManager) messageList.getLayoutManager()).findLastVisibleItemPosition() == dataset.size() - 1)
//                    return;
//                messageList.postDelayed(new Runnable() {
//                    @Override
//                    public void run() {
//                        messageList.smoothScrollBy(0, dy);
//                    }
//
//                }, 100);
//            }
//        });

        HubConnection connection = HubConnectionBuilder.create("https://192.168.10.2:53998/ChatHub").build();




        connection.on("ReceiveMessage", (user, message)->{
            dataset.add(user+" "+message);
            Log.d("Try_to_receive_a_message_from_server", message);
        }, String.class, String.class);

        connection.start();

        if(connection.getConnectionState() == HubConnectionState.CONNECTED)
            connection.send("JoinGroup", "people");

        Button button = (Button) rootView.findViewById(R.id.button);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String typed_message = String.valueOf(((TextView) rootView.findViewById(R.id.input_message_field)).getText());
                    Log.d("Try_to_send_message_to_server", typed_message);
                    connection.send("SendMessage", "man", "people", typed_message);

            }
        });

        return rootView;
    }
}

