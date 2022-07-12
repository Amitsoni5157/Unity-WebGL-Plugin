mergeInto(LibraryManager.library,
{
	Alert: function()
	{
		window.alert("Unity to JS Alert!");
	},

	AlertParam: function(param)
	{
		window.alert(Pointer_stringify(param));
	},

	GetInt: function()
	{
		var num = 100;
		return num;
	},

	GetString: function()
	{
		var str = "This is string returned by JS";
		var bufferSize = lengthBytesUTF8(str) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(str, buffer, bufferSize);
		return buffer;
	},
});