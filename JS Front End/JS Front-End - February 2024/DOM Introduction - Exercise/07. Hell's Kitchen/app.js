function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      const inputElement = document.querySelector('textarea');
      const ouputBestRestaurantElement = document.querySelector('#bestRestaurant p');
      const ouputBestWorkersElement = document.querySelector('#workers p');

      const restaurantInfo = JSON.parse(inputElement.value);

      let restaurants = [];

      for (const row of restaurantInfo) {
         const [restaurantName, workersAsString] = row.split(' - ');

         const workersToArray = workersAsString.split(', ');

         const workers = [];

         for (const worker of workersToArray) {
            const [workerName, workerSalary] = worker.split(' ');

            const workerObj = {
               workerName: workerName,
               workerSalary: Number(workerSalary)
            }

            workers.push(workerObj);
         }

         if(restaurants.some(restaurant => restaurant.restaurantName === restaurantName)){
            const currRestaurant = restaurants.find(restaurant => restaurant.restaurantName === restaurantName)
            
            for(const worker of workers){
               currRestaurant.workers.push(worker);
            }
         } else{
            const restaurant = {
               restaurantName,
               averageSalary: 0,
               bestSalary: 0, 
               workers
            }
            
            restaurants.push(restaurant);
         }
      }

      //Setting the Average selary for every restaurant
      for(const restaurant of restaurants){
         let workerSalarySum = 0;
         let workersCount = restaurant.workers.length;

         for(const worker of restaurant.workers){
            workerSalarySum += worker.workerSalary;
         }
         restaurant.averageSalary = workerSalarySum / workersCount;
      }

      //Setting the Best selary for every restaurant
      for(const restaurant of restaurants){
         let highestRestaurantWorkersSalary = 0;
         for(const worker of restaurant.workers){
            if(worker.workerSalary > highestRestaurantWorkersSalary){
               highestRestaurantWorkersSalary = worker.workerSalary;
            }
         }
         restaurant.bestSalary = highestRestaurantWorkersSalary;
      }

      //Finding the restaurant with the highest average salary
      let highestRestaurantWorkersSalary = 0;
      for(const restaurant of restaurants){
         if(restaurant.averageSalary > highestRestaurantWorkersSalary){
            highestRestaurantWorkersSalary = restaurant.averageSalary;
         }
      }

      restaurants = restaurants.filter(restaurant => restaurant.averageSalary === highestRestaurantWorkersSalary)

      for(const r of restaurants){
         ouputBestRestaurantElement.textContent = `Name: ${r.restaurantName} Average Salary: ${r.averageSalary.toFixed(2)} Best Salary: ${r.bestSalary.toFixed(2)}`;
         
         r.workers.sort((a, b) => b.workerSalary - a.workerSalary)
         for(const worker of r.workers){
            ouputBestWorkersElement.textContent += `Name: ${worker.workerName} With Salary: ${worker.workerSalary} `;
         }
      }
   }
}