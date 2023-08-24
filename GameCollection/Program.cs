using GameCollection;
using System.Text;

View view = new View();

bool quit = false;

while( !quit ) {

    int choice = view.Menu();

    switch ( choice ) {
    
        case 0:
            view.ListAll();
            break;
        case 1:
            view.ListByCategory();
            break;
        case 2:
            view.ShowDetail();
            break;
        case 3:
            view.ListCategories(); 
            break;
        case 4:
            view.CreateGame();
            break;
        case 5:
            view.CreateCategory();
            break;
        case 6:
            view.UpdateCategory();
            break;
        case 7:
            quit = true;
            break;
    }

}