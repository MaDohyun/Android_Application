const enemys = [];
const cats = [];
const stones = [];
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
  let jump = null;
  let jumpslow = null;
  let player
  let playerstate = false;
  let plyaerwalkstate = false;
  let enemyresult = false;
  let nekoresult = false;
  let x1;
  let y1;
  let px;
  let py;    
  let score = 0.0;
  let situation = "playing";
    window.addEventListener("load", init);
    window.addEventListener("keydown", handleKeydown);
    window.addEventListener("keyup", handleKeyup);
   let stage
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
      function  drawPlayer(image,x,y){
      player = new createjs.Bitmap(image);
      player.x = x;
      player.y = y; 
      stage.addChild(player);
      }
      class Enemy{
         	constructor(){
       		this.x = 0.0;
       		this.y = 0.0;
       		       	}
       	draw(x,y){
       			this.object = new createjs.Bitmap("image/bomb.png");
        		this.object.x = x;
       		this.object.y = y;
       		stage.addChild(this.object);
       		enemys.push(this);
       }
        }
         class Cat{
         	constructor(){
       		this.x = 0.0;
       		this.y = 0.0;
       		       	}
       	draw(x,y){
                        this.object = new createjs.Bitmap("image/neko.png");
       	        		this.object.x = x;
       		            this.object.y = y;
       		stage.addChild(this.object);
       		cats.push(this);
        }
        }

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
      	case "playing":
      score += 1;
      x1 = player.x;
      y1= player.y;
      enemytimer1 += 1;
      enemytimer2 += 1;
      enemytimer3 += 1;
      nekotimer1 += 1;
      nekotimer2 += 1;
        stonetimer += 1;
      cloudtimer += 1;
      timer += 1;
      if(jump ==null){
      	if(timer > walkspeed && plyaerwalkstate ==true){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio1.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
      	timer = 0;
      	plyaerwalkstate = false;
          	}
         if(timer > walkspeed && plyaerwalkstate ==false){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio2.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
      	timer = 0;
      	plyaerwalkstate = true;
          	}
      }   
    if(enemytimer1 == 10){
   enemyrandomnum1 = 90+Math.floor(Math.random() * enemyappearance)+1;
           }
      if(enemytimer1 == enemyrandomnum1){
        enemy = new Enemy;
       	enemy.draw(800,325);
      	enemytimer1 = 0;
      }
         if(enemytimer2 == 10){
   enemyrandomnum2 = 200+Math.floor(Math.random() * enemyappearance)+1;
           }
      if(enemytimer2 == enemyrandomnum2){
        enemy = new Enemy;
       	enemy.draw(800,125);
      	enemytimer2 = 0;
      }
       if(enemytimer3 == 10){
   enemyrandomnum3 = 170+Math.floor(Math.random() * enemyappearance)+1;
           }
      if(enemytimer3 == enemyrandomnum3){
        enemy = new Enemy;
       	enemy.draw(800,325);
      	enemytimer3 = 0;
      }
       if(nekotimer1 == 10){
  catrandomnum1 = 30+Math.floor(Math.random() * enemyappearance)+1;
           }
      if(nekotimer1 == catrandomnum1){
        cat = new Cat;
       	cat.draw(800,325);
      	nekotimer1 = 0;
      }
       if(nekotimer2 == 10){
   catrandomnum2 = 50+Math.floor(Math.random() * enemyappearance)+1;
           }
      if(nekotimer2 == catrandomnum2){
        cat = new Cat;
       	cat.draw(800,125);
      	nekotimer2 = 0;
      }
      if(stonetimer == 10){
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
        	let cloudheight = 10 + Math.floor(Math.random() * 40) + 1
              		cloud = new Cloud;
      	cloud.draw(800,cloudheight);
             	cloudtimer = 0;
            }
            label.text = "Score:"+score;
            label2.text = "";
                    
      for(let i = 0; i< enemys.length ; i++){
      	      		if(enemys[i].object.x < -50){
      		stage.removeChild(enemys[i].object);
      		enemys.splice(i,1);
          	}
          	enemys[i].object.x -= gamespeed;

      }
         for(let i = 0; i< stones.length ; i++){
      
      		if(stones[i].object.x < -50){
      		stage.removeChild(stones[i].object);
      		stones.splice(i,1);
          	}
          	 stones[i].object.x -= gamespeed;
      }
          for(let i = 0; i< clouds.length ; i++){
      
      		if(clouds[i].object.x < -50){
      		stage.removeChild(clouds[i].object);
      		clouds.splice(i,1);
      		          	}
          	 clouds[i].object.x -= gamespeed;
      }
      for(let i = 0; i< cats.length ; i++){
      
      		if(cats[i].object.x < -50){
      		stage.removeChild(cats[i].object);
      		cats.splice(i,1);
          	}
          	 cats[i].object.x -= gamespeed;
      }
            if( jump == true){
      	player.y -= jumpspeed;
      	 jumptimer += 1;
           }
      if(jumptimer == 30){
           	jump = false;
           	jumptimer =0;
              }
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
      if(jumpslow == true){
                jumpspeed = jumpslowspeed;
          }
          if(jumpslow ==true && playerstate ==false){
        px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio3.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
        playerstate = true;	
          }
      if(jumpslow == false){
          	jumpspeed = jumpspeed1;
          }
           if(jumpslow == false && playerstate ==true){
           	  px = x1;						
      	py = y1;
      	stage.removeChild(player);
      	player = new createjs.Bitmap("image/mio1.png");
      	player.x = px;
      	player.y = py;
      	stage.addChild(player);
        playerstate = false;	
           }
       for(let i = 0; i< enemys.length ; i++){
            	if(enermyCollision(enemys[i].object) == true){
            	    label2.text = "Press Space";
            		situation = "fail";
                       break;

            	}
            	
         }
          for(let i = 0; i< cats.length ; i++){
            	if(nekoCollision(cats[i].object) == true){
            		score += 1000;
            stage.removeChild(cats[i].object);
      		cats.splice(i,1);                          		
            		result =  false;
                    		         }
         }
                   stage.update();      
                   case "fail":
          	break;
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
  playerstate = false;
 plyaerwalkstate = false;
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
      	if(situation == "fail"){
      	if(keyCode == 32){
      		situation = "restart";
      	      		 }
      	}

      }
         function handleKeyup(event){
      let keyCode = event.keyCode;
      if(jumpslow && jump == false){
      	if(keyCode == 32){
      		jumpslow = false;
      	}
      }
            }
      function enermyCollision(object){
      	      	let d = Math.sqrt((player.x+58-object.x)* (player.x+58-object.x)+((player.y+50)-(object.y+15))*((player.y+50)-(object.y+15)));
         	if(d < enemysize){
      		result = true;
      		return result;
        	}
        	result = false;
        	return result;
      }
      function nekoCollision(object){
      	let d = Math.sqrt((player.x+58-object.x)* (player.x+58-object.x)+((player.y+50)-(object.y+15))*((player.y+50)-(object.y+15)));
         	if(d < nekosize){
      		result = true;
      		return result;
        	}
        	result = false;
        	return result;
      }
  
     