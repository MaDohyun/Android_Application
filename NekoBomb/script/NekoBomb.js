//爆弾の配列
const enemys = [];
//猫の配列
const cats = [];
//石の配列
const stones = [];
//雲の配列
const clouds = [];
  const gamespeed = 7;
  const enemysize = 25.0;
  const nekosize = 40.0;
  const jumpspeed1 = 7.0;
  const jumpslowspeed = 2.0;
  const walkspeed = 5;
  const ground = 290;
  let jumpspeed =7.0;
  let enemytimer1 = 0.0;
  let enemytimer2 = 0.0;
  let enemytimer3 = 0.0;
  let nekotimer1 = 0.0;
   let nekotimer2 = 0.0;
  let enemyappearance = 90;
  let enemyrandomnum1;
  let enemyrandomnum2;
  let enemyrandomnum3;
   let catrandomnum1;
  let catrandomnum2;
    let stonetimer = 0.0;
  let cloudtimer = 0.0;
  let timer = 0.0;
  let jumptimer = 0.0;
  let label = new createjs.Text("", "30px sans-serif", "Black");  
  let label2 = new createjs.Text("", "30px sans-serif", "Red");  
  let enemy;
  let cat;
  let stone;
  let cloud;
  let background;
  //現在ジャンプしているかを判断
  let jump = null;
  //現在ジャンプを遅くしているかを判断
  let jumpslow = null;
  let player
  let playerJumpSlowState = false;
  let playerwalkLeftRightstate = false;
  let enemyresult = false;
  let nekoresult = false;
  //プレイヤーのx座標
  let x1;
   //プレイヤーのy座標
  let y1;
   //プレイヤーの臨時x座標
  let px;
   //プレイヤーの臨時y座標
  let py;    
  let score = 0.0;
  let situation = "playing";
    window.addEventListener("load", init);
    window.addEventListener("keydown", handleKeydown);
    window.addEventListener("keyup", handleKeyup);
   let stage
   //最初の設定
    function init() {
      stage = new createjs.Stage("myCanvas");
      drawPlayer("image/mio1.png",120,ground);
       background = new BackGround;
       label2.x = 300;
       label2.y = 220;
         stage.addChild(label);
         stage.addChild(label2);
             stage.update();
      createjs.Ticker.timingMode = createjs.Ticker.RAF;
      createjs.Ticker.addEventListener("tick", handleTick);
    }
    //プレイヤーを描く
      function  drawPlayer(image,x,y){
      player = new createjs.Bitmap(image);
      player.x = x;
      player.y = y; 
      stage.addChild(player);
      }
      //爆弾のクラス
      class Enemy{
         	constructor(){
       		this.x = 0.0;
       		this.y = 0.0;
       		       	}
       		       	//爆弾を描く
       	draw(x,y){
       			this.object = new createjs.Bitmap("image/bomb.png");
        		this.object.x = x;
       		this.object.y = y;
       		stage.addChild(this.object);
       		enemys.push(this);
       }
        }
         //猫のクラス
         class Cat{
         	constructor(){
       		this.x = 0.0;
       		this.y = 0.0;
       		       	}
       		       	//猫を描く
       		       	       	draw(x,y){
                        this.object = new createjs.Bitmap("image/neko.png");
       	        		this.object.x = x;
       		            this.object.y = y;
       		stage.addChild(this.object);
       		cats.push(this);
        }
        }
//背景
        class BackGround{
        	constructor(){
        		this.x = 0.0;
        		this.y = 0.0;
        		this.object = new createjs.Shape();
        	this.object.graphics.beginFill("#FFF5FF");
           this.object.graphics.drawRect(0,0,720,480);
        	stage.addChild(this.object);
        this.object.graphics.beginFill("#000000");
        this.object.graphics.drawRoundRect(0, 390, 720, 8, 0, 0);
        stage.addChild(this.object);
        	}
        }
        //石
        	class Stone{
        			constructor(){
        				this.x = 0.0;
        				this.y = 0.0;
                	}
                		draw(x,y){
                			this.object = new createjs.Shape();
       	    this.object.graphics.beginFill("#000000");
       		this.object.graphics.drawCircle(0, 0, 2);
       		this.object.x = x;
       		this.object.y = y;
       		stage.addChild(this.object);
       		stones.push(this);
       		}
                    }
                    //雲
                    	class Cloud{
        			constructor(){
        				this.x = 0.0;
        				this.y = 0.0;
                	}
                		draw(x,y){
                		this.object = new createjs.Bitmap("image/cloud.png");
       	        		this.object.x = x;
       		            this.object.y = y;
       		stage.addChild(this.object);
       		clouds.push(this);
       		}
                    }

      function handleTick() {  
      switch(situation){
        //ゲームがplayingの状態の場合
      	case "playing":
      	     //点数は自動に上がる
      score += 1;
      //プレイヤーの位置を設定
      x1 = player.x;
      y1= player.y;
      //タイマーによってオブジェクトが出る
      enemytimer1 += 1;
      enemytimer2 += 1;
      enemytimer3 += 1;
      nekotimer1 += 1;
      nekotimer2 += 1;
        stonetimer += 1;
      cloudtimer += 1;
      timer += 1;
      //ジャンプしていない場合、プレイヤーは地面に近い指定された座標に移動する。
      if(jump ==null){
          //歩くアニメーションを作るために二枚のイメージを交互に描く。playerwalkLeftRightstateがtrueかfalseかによってイメージを交換
      	if(timer > walkspeed && playerwalkLeftRightstate ==true){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio1.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
      	timer = 0;
      	playerwalkLeftRightstate = false;
          	}
         if(timer > walkspeed && playerwalkLeftRightstate ==false){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio2.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
      	timer = 0;
      	playerwalkLeftRightstate = true;
          	}
      }   
    if(enemytimer1 == 10){
   enemyrandomnum1 = 90+Math.floor(Math.random() * enemyappearance)+1;
           }
           //タイマーをランダムにセットして爆弾が出る時間をランダムにセッティングする。
      if(enemytimer1 == enemyrandomnum1){
        enemy = new Enemy;
       	enemy.draw(800,325);
      	enemytimer1 = 0;
      }
         if(enemytimer2 == 10){
   enemyrandomnum2 = 200+Math.floor(Math.random() * enemyappearance)+1;
           }
      //タイマーをランダムにセットして爆弾が出る時間をランダムにセッティングする。
      if(enemytimer2 == enemyrandomnum2){
        enemy = new Enemy;
       	enemy.draw(800,125);
      	enemytimer2 = 0;
      }
       if(enemytimer3 == 10){
   enemyrandomnum3 = 170+Math.floor(Math.random() * enemyappearance)+1;
           }
      //タイマーをランダムにセットして爆弾が出る時間をランダムにセッティングする。
      if(enemytimer3 == enemyrandomnum3){
        enemy = new Enemy;
       	enemy.draw(800,325);
      	enemytimer3 = 0;
      }
       if(nekotimer1 == 10){
  catrandomnum1 = 30+Math.floor(Math.random() * enemyappearance)+1;
           }
    //タイマーをランダムにセットして猫が出る時間をランダムにセッティングする。
      if(nekotimer1 == catrandomnum1){
        cat = new Cat;
       	cat.draw(800,325);
      	nekotimer1 = 0;
      }
       if(nekotimer2 == 10){
   catrandomnum2 = 50+Math.floor(Math.random() * enemyappearance)+1;
           }
     //タイマーをランダムにセットして猫が出る時間をランダムにセッティングする。
      if(nekotimer2 == catrandomnum2){
        cat = new Cat;
       	cat.draw(800,125);
      	nekotimer2 = 0;
      }
      if(stonetimer == 10){
          //石をランダムな位置に生成
        	let stoneheight = 410 + Math.floor(Math.random() * 50) + 1
              	stone = new Stone;
      	stone.draw(800,stoneheight);
      	      		            }
    　 if(stonetimer == 20){
        	let stoneheight = 410 + Math.floor(Math.random() * 50) + 1
              	stone = new Stone;
      	stone.draw(800,stoneheight);
      	      		            }
        if(stonetimer == 40){
        	let stoneheight = 410 + Math.floor(Math.random() * 50) + 1
              	stone = new Stone;
      	stone.draw(800,stoneheight);
      	stonetimer = 0;
      		            }
            if(cloudtimer == 70){
                //雲をランダムな位置に生成
        	let cloudheight = 10 + Math.floor(Math.random() * 40) + 1
              		cloud = new Cloud;
      	cloud.draw(800,cloudheight);
             	cloudtimer = 0;
            }
            label.text = "Score:"+score;
            label2.text = "";
                    
                    //爆弾が画面の外に出たら破壊
      for(let i = 0; i< enemys.length ; i++){
      	      		if(enemys[i].object.x < -50){
      		stage.removeChild(enemys[i].object);
      		enemys.splice(i,1);
          	}
          	enemys[i].object.x -= gamespeed;

      }
      //石が画面の外に出たら破壊

         for(let i = 0; i< stones.length ; i++){
      
      		if(stones[i].object.x < -50){
      		stage.removeChild(stones[i].object);
      		stones.splice(i,1);
          	}
          	 stones[i].object.x -= gamespeed;
      }
      //雲が画面の外に出たら破壊

          for(let i = 0; i< clouds.length ; i++){
      
      		if(clouds[i].object.x < -50){
      		stage.removeChild(clouds[i].object);
      		clouds.splice(i,1);
      		          	}
          	 clouds[i].object.x -= gamespeed;
      }
      //猫が画面の外に出たら破壊

      for(let i = 0; i< cats.length ; i++){
      
      		if(cats[i].object.x < -50){
      		stage.removeChild(cats[i].object);
      		cats.splice(i,1);
          	}
          	 cats[i].object.x -= gamespeed;
      }
      //プレイヤーはジャンプのタイマーほどジャンプする。
            if( jump == true){
      	player.y -= jumpspeed;
      	 jumptimer += 1;
           }
      if(jumptimer == 30){
           	jump = false;
           	jumptimer =0;
              }
              //ジャンプじゃない場合地面まで落ちる。
      if(jump == false){
      	if(player.y <ground){
                	player.y +=jumpspeed;
              }
          }
      if(jump == false &&player.y >= ground){
          	jumpslow = false;
          	jumpspeed = jumpspeed1;
          	jump = null;
          }
          //ジャンプボタンを二回押して落ちる速度が遅くなる場合
      if(jumpslow == true){
                jumpspeed = jumpslowspeed;
          }
          if(jumpslow ==true && playerJumpSlowState ==false){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	//イメージを変える。
      	player = new createjs.Bitmap("image/mio3.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
        playerJumpSlowState = true;	
          }
      if(jumpslow == false){
          	jumpspeed = jumpspeed1;
          }
           if(jumpslow == false && playerJumpSlowState ==true){
           	  px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio1.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
        playerJumpSlowState = false;	
           }
           //爆弾に当たる場合
       for(let i = 0; i< enemys.length ; i++){
            	if(enermyCollision(enemys[i].object) == true){
            	    label2.text = "Press Space";
            		situation = "fail";
                       break;

            	}
            	
         }
         //猫に当たる場合
          for(let i = 0; i< cats.length ; i++){
            	if(nekoCollision(cats[i].object) == true){
            		score += 1000;
            stage.removeChild(cats[i].object);
      		cats.splice(i,1);                          		
            		result =  false;
                    		         }
         }
                   stage.update();      
                    //ゲームがfailの状態の場合止まる
                   case "fail":
          	break;
          	 //ゲームがrestartの状態の場合オブジェクトを全部破壊してplaying状態にする。
      case "restart":
      	for(let i = 0; i< enemys.length ; i++){
            		stage.removeChild(enemys[i].object);
          	}
          	for(let i = 0; i< cats.length ; i++){
            		stage.removeChild(cats[i].object);          
            			}
             	player.x = 120;
      	player.y = ground;
      enemytimer1 = 0.0;
  　enemytimer2 = 0.0;
  　 enemytimer3 = 0.0;
  nekotimer1 = 0.0;
   nekotimer2 = 0.0;
 stonetimer = 0.0;
  cloudtimer = 0.0;
  timer = 0.0;
  jumptimer = 0.0;
  jump = null;
  jumpslow = null;
  playerJumpSlowState = false;
 playerwalkLeftRightstate = false;
  enemyresult = false;
  nekoresult = false;
  score = 0.0;
  
    cats.length = 0;
  enemys.length = 0;
      situation = "playing";
      	break;
      }
      }
      function handleKeydown(event){
      let keyCode = event.keyCode;
      //Spaceキーを押す時
      	if(jump == null){
      	if(keyCode == 32){
      		jump = true;
      	}
      	}
      	if(jump == false){
      	if(keyCode == 32){
      		jumpslow = true;
      		 }
      	}
      	//game overの場合はrestartする。
      	if(situation == "fail"){
      	if(keyCode == 32){
      		situation = "restart";
      	      		 }
      	}

      }
         function handleKeyup(event){
      let keyCode = event.keyCode;
      //Spaceキーから外す時
      if(jumpslow && jump == false){
      	if(keyCode == 32){
      		jumpslow = false;
      	}
      }
            }
            //爆弾に当たる範囲を判断
      function enermyCollision(object){
      	      	let d = Math.sqrt((player.x+58-object.x)* (player.x+58-object.x)+((player.y+50)-(object.y+15))*((player.y+50)-(object.y+15)));
         	if(d < enemysize){
      		result = true;
      		return result;
        	}
        	result = false;
        	return result;
      }
        //猫に当たる範囲を判断
      function nekoCollision(object){
      	let d = Math.sqrt((player.x+58-object.x)* (player.x+58-object.x)+((player.y+50)-(object.y+15))*((player.y+50)-(object.y+15)));
         	if(d < nekosize){
      		result = true;
      		return result;
        	}
        	result = false;
        	return result;
      }
  
     