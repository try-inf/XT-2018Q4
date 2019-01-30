function chooseItem() {
	var av = document.getElementById("availableField");
	var av_opt = av.options[av.selectedIndex].value;
	var sel = document.getElementById("selectedField");
	var sel_opt = [];
	var av_arr = [];

	for (var i=0; i < av.length; i++) {
		if (av[i].selected) {
			sel_opt.push(av[i].value);

			av_arr[i] = av.options[i].value;
			sel_opt[i] = document.createElement("option");
			sel_opt[i].text = av_arr[i];
			
			sel.options.add(sel_opt[i]);		
		}
	}
	
	for (var i=av.length-1; i >= 0; i--) {
		av.remove(av.selectedIndex);	
	}
}

function unChooseItem() {
	var av = document.getElementById("availableField");
	var sel = document.getElementById("selectedField");
	var sel_opt = sel.options[sel.selectedIndex].value;
	var av_opt = [];
	var sel_arr = [];

	for (var i=0; i < sel.length; i++) {
		if (sel[i].selected) {
			av_opt.push(sel[i].value);

			sel_arr[i] = sel.options[i].value;
			av_opt[i] = document.createElement("option");
			av_opt[i].text = sel_arr[i];
			
			av.options.add(av_opt[i]);		
		}
	}

	for (var i=sel.length - 1; i >= 0; i--) {
		sel.remove(sel.selectedIndex);
	}
}

function chooseAll() {
	var av = document.getElementById("availableField");
	var sel = document.getElementById("selectedField");
	var sel_opt = [];
	var av_arr = [];

	for (var i = 0; i < av.length; i++) {	
		av_arr[i] = av.options[i].value;
		sel_opt[i] = document.createElement("option");
		sel_opt[i].text = av_arr[i];
		sel.options.add(sel_opt[i]);		
	}	

	av.options.length = 0;
}	

function unChooseAll() {
	var av = document.getElementById("availableField");
	var sel = document.getElementById("selectedField");
	var av_opt = [];
	var sel_arr = [];

	for (var i = 0; i < sel.length; i++) {	
		sel_arr[i] = sel.options[i].value;
		av_opt[i] = document.createElement("option");
		av_opt[i].text = sel_arr[i];
		av.options.add(av_opt[i]);		
	}	

	sel.options.length = 0;
}	



