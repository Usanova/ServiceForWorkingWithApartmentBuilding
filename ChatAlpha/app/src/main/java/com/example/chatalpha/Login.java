package com.example.chatalpha;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Login extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
    }
    public void clickEnter(View view){
        startActivity(new Intent(this, MainActivity.class));
    }
    public void clickRegister(View view){
        Toast.makeText(Login.this,"АГАГА",Toast.LENGTH_LONG).show();
    }
}
