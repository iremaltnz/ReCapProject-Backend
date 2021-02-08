// ogrno:[181213020]
//ad:[Irem Altinoz]

#include<stdio.h>
#include<time.h>
#include<stdlib.h>

/*FILE *fp;
int kullanici1;
int kullanici2;
   
   int bas=0,son=99;
   time_t start,fin;

   long sayac1=0;
   int sayac1_2=0;
   long sayac2=0;
   int sayac2_2=0;
   int toplam=0;

   int sayi;
   int a,b;
*/
   
void oyuncu1(){
 char text[100]="oyuncu1 tahmini:";
 
 printf("Oyuncu1 [%d %d] arasi bir sayi girsin\n",bas,son);
   
   time(&start);

      scanf("%d",&kullanici1);

   time(&fin);
 

 sayac1_2=difftime(start,fin);
 sayac1_2=(-sayac1_2);

sayac1=sayac1_2*1000;
 toplam+=sayac1_2;
   fprintf(fp,"%s %d \n",text,kullanici1);
   fprintf(fp,"Oyuncu1 gecen sure : %ld ms\n",sayac1);

 
}

void oyuncu2(){
   char text[100]="oyuncu2 in tahmini:";
 printf("Oyuncu2 [%d %d] arasi bir sayi girsin\n",bas,son);
   time(&start);   

      scanf("%d",&kullanici2);

   time(&fin);
   

 sayac2_2=difftime(start,fin);
 sayac2_2=(-sayac2_2);

 sayac2=sayac2_2*1000;
   toplam+=sayac2_2;

      fprintf(fp,"%s %d \n",text,kullanici2);
   fprintf(fp,"Oyuncu2 gecen sure : %04ld ms\n",sayac2);

}

int main(int argc , char*argv[]){

   a=atoi(argv[1]);
   b=atoi(argv[2]);

   srand(time(NULL));
   sayi=rand()%99;

   char text[100]="Deger:";
   fp=fopen("oyun_181213020.txt","w");
   fprintf(fp,"%s %d\n",text,sayi);
   fprintf(fp,"A:%d  B:%d\n",a,b);

   while(1){
     oyuncu1();
     if(sayac1_2>a){
         printf("Sure doldu...");
         break;
      }

      if(kullanici1>son || kullanici1<bas){
      printf("Hata oyuncu1 kaybetti");
      fprintf(fp,"%s","Kazanan oyuncu2\n");
      fprintf(fp,"Toplam sure : %d ms ",toplam*1000);
      break;
      }
     
        
     else  if(kullanici1==sayi){
      printf("Dogru Oyuncu 1 oyunu kaybetti..");
      fprintf(fp,"%s\n","Kazanan : oyucncu2");
      fprintf(fp,"Toplam sure : %d ms",toplam*1000);
      break;
      }
      else{
         printf("Yanlis. Gecen sure : %ld ms \n",sayac1);
      }
    
      if(sayi<son && sayi>kullanici1){
      bas=kullanici1;
      }
      else if (bas<sayi && kullanici1>sayi){
      son=kullanici1;}
       
       
       oyuncu2();

    if(sayac2_2>a){
         printf("Sure doldu...");
         break;
      }

      if(kullanici2>son || kullanici2<bas){
      printf("Hata oyuncu2 kaybetti");
      fprintf(fp,"%s","Kazanan oyuncu1\n");
      fprintf(fp,"Toplam sure : %d ms",toplam*1000);
      break;
      }
     
        
     else  if(kullanici2==sayi){
      printf("Dogru . Oyuncu 2 oyunu kaybetti..");
       fprintf(fp,"%s\n","Kazanan : oyucncu1");
      fprintf(fp,"Toplam sure : %d ms",toplam*1000);
      break;
      }
      else{
         printf("Yanlis. Gecen sure : %ld ms \n",sayac2);
      }
    
      if(sayi<son && sayi>kullanici2){
      bas=kullanici2;
      }
      else if (bas<sayi && kullanici2>sayi){
      son=kullanici2;}
       
       
       
      if(toplam>b){
         printf("Sure bitti kazanan yok.\n");
         fprintf(fp,"%s","Sure bitti kazanan yok\n");
         break;
      }       
       
   }
}
