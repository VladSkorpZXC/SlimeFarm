mergeInto(LibraryManager.library,
{
	AddCoinExtern: function(value)
	{
		ysdk.adv.showRewardedVideo({
	    callbacks: {
	        onOpen: () => {
	          console.log('Video ad open.');
	        },
	        onRewarded: () => {
	          console.log('Rewarded!');
	          myGameInstance.SendMessage("Main Camera", "AddCoin", value);
	          myGameInstance.SendMessage("Main Camera", "StartMusic");
	        },
	        onClose: () => {
	          console.log('Video ad closed.');
			  myGameInstance.SendMessage("Main Camera", "StartMusic");
	        },
	        onError: (e) => {
	          console.log('Error while open video ad:', e);
	          myGameInstance.SendMessage("Main Camera", "StartMusic");
	        }
	    }
		})
	},

	AddCristalExtern: function(value)
	{
		ysdk.adv.showRewardedVideo({
	    callbacks: {
	        onOpen: () => {
	          console.log('Video ad open.');
	        },
	        onRewarded: () => {
	          console.log('Rewarded!');
	          myGameInstance.SendMessage("Main Camera", "AddCristal", value);
	          myGameInstance.SendMessage("Main Camera", "StartMusic");
	        },
	        onClose: () => {
	          console.log('Video ad closed.');
			  myGameInstance.SendMessage("Main Camera", "StartMusic");
	        },
	        onError: (e) => {
	          console.log('Error while open video ad:', e);
	          myGameInstance.SendMessage("Main Camera", "StartMusic");ы
	        }
	    }
		})
	},

	GetLang: function(){
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},

});