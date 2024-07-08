import { User } from "./user.model";

enum Category
{
    Furniture, Vacation, Clothing, Events
}
export class PresentList
{

    id: number=0;
    name: string="";
    donorId:string ='';
    cost:number=10;
    categoryId:Category=0;
    image:string="";
    quentity:number=0;
    isRuffled:boolean=false;
    winner?:User = new User()
}