let g_menu = API.createMenu("Eden Role Play", "Oluşum Düzenleme | Yönetici", 0, 0, 6, true);
let g_menu_player = API.createMenu("Eden Role Play", "Oluşum Düzenleme | Oyuncu", 0, 0, 6, true);
let g_menu_player_members = API.createMenu("Eden Role Play", "Oluşum Düzenleme | Üyeler", 0, 0, 6, true);
let members;
let memberNames;
g_menu_player_members.Visible = false;
let state = false;


API.onServerEventTrigger.connect(function (eventName, args)
{
    if(eventName == "factionMenu")
    {
        
        if (state == true)
        {
            API.sendNotification("Şu anda zaten bir düzenleme yapıyorsunuz. \"BackSpace\" tuşu ile önce iptal etmelisiniz.");
        }
        else
        {
            g_menu.AddItem(API.createMenuItem("Oluşumun Adı", " " + args[0]));
            g_menu.AddItem(API.createMenuItem("Faction ID", "ID - " + args[3]));
            g_menu.AddItem(API.createMenuItem("Oluşum Sahibi & Kurucusu", " " + args[1] + " - " + args[2]));
            g_menu.AddItem(API.createMenuItem("Üye Sayısı", " " + args[4] + " Oyuncu"));
            g_menu.Visible = true;
            state = true;
        }

    }
    else if(eventName == "creatingFactionForPlayer")
    {   	
    	API.triggerServerEvent("creatingFactionForPlayer", API.getUserInput("32 karakter uzunluğunda oluşumun ismini giriniz:", 256), args[0]);
    }
    else if(eventName == "creatingMenuForPlayer")
    {
    	if (state == true) {
    		API.sendNotification("Şu anda zaten bir düzenleme yapıyorsunuz. \"BackSpace\" tuşu ile önce iptal etmelisiniz.");
    	}
    	else
    	{
    		g_menu_player.AddItem(API.createMenuItem("Oluşumunuzun Adı", args[0]));
    		g_menu_player.AddItem(API.createMenuItem("Faction ID", "ID - " + args[1]));
    		g_menu_player.AddItem(API.createMenuItem("Oluşum Sahibi & Kurucusu", args[2] + " - " + args[3]));
    		g_menu_player.AddItem(API.createMenuItem("Üye Sayısı", args[4] + " Oyuncu (( Oluşum üyelerinin listesi için tıklayın! ))"));
    		g_menu_player.AddItem(API.createMenuItem("Araç Ekle", "İçerisinde bulunduğunuz aracınızı oluşumun üzerine geçirir. (( Pasif ))"));
    		g_menu_player.Visible = true;
    		members = args[4];
    		memberNames = JSON.parse(args[5]);
    		state = true;
    	}
    }
});
g_menu.OnItemSelect.connect(function (sender, item, index)
{
	switch(index)
	{
		case 0:
			{
				API.getUserInput("32 karakter uzunluğunda oluşumun yeni ismini giriniz:", 256);
                //triggereventonServerSide
				break;
			}
		case 2:
			{
				API.getUserInput("Oluşumu üzerine atamak istediğiniz oyuncunun clientID'sini giriniz:", 256);
				//triggereventonServerSide
				break;
			}
		default: API.sendNotification("Hatalı bir işlem gerçekleştirdiniz.");
	}
    
});
g_menu_player.OnItemSelect.connect(function (sender, item, index) {
    switch (index) {
        case 0:
            {
                API.getUserInput("32 karakter uzunluğunda oluşumunuzun yeni ismini giriniz:", 256);
                //triggereventonServerSide
                break;
            }
        case 2:
            {
                API.sendNotification("Oluşum kurucusu yöneticiler tarafından değiştirilebilir.");
                break;
            }
        case 3:
            {
                g_menu_player.Clear();
                for(var i = 0; i<members; i++)
                {
                    g_menu_player_members.AddItem(API.createMenuItem(memberNames[i], "~r~Oluşumdan çıkartmak için üzerine tıklayın!"));
                }
                state = true;
                g_menu_player.Visible = false;
                g_menu_player_members.Visible = true;
            }
        default: API.sendNotification("Hatalı bir seçim gerçekleştirdiniz.");
    }

});
API.onUpdate.connect(function ()
{
	API.drawMenu(g_menu);
	API.drawMenu(g_menu_player);
	API.drawMenu(g_menu_player_members);
});
g_menu.OnMenuClose.connect(function ()
{
    g_menu.Visible = false;
    g_menu.Clear();
    state = false;


});
g_menu_player.OnMenuClose.connect(function () {
	g_menu_player.Visible = false;
	g_menu_player.Clear();
	state = false;
});
g_menu_player_members.OnMenuClose.connect(function () {
    g_menu_player_members.Visible = false;
    g_menu_player_members.Clear();
    state = false;
});