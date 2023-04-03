function passed (list) { 
    let passed = 0;
    const initial = 0;
    let sum = list.reduce((acc, val) =>  {
        if(val <= 18){
            passed++;
            return acc + val;
        }
        return acc;
    }
      , initial);
    if(passed < 1){
      return "No pass scores registered."
    }
    return Math.round(sum / passed);
  } 

  console.log(passed([10,10,10,18,20,20]));