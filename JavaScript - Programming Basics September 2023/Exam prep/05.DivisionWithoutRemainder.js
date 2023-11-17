function divisionWithoutReminder(input){
    let n = Number(input[0]);
            let p1 = 0;
            let p2 = 0;
            let p3 = 0;
            let count = 0;

            for (let i = 1; i <= n; i++)
            {
                let numb = Number(input[i]);
                count++;
                if (numb % 2 == 0)
                {
                    //count++;
                    //p1 = count * 1.00 / 10 * 100;
                    p1++;
                }
                if (numb % 3 == 0)
                {
                    //count++;
                    //p2 = count * 1.00 / 10 * 100;
                    p2++;
                }
                if (numb % 4 == 0)
                {
                    //count++;
                    //p3 = count * 1.00 / 10 * 100;
                    p3++;
                }
            }

            let p1Percent = (p1 / count) * 100;
            let p2Percent = (p2 / count) * 100;
            let p3Percent = (p3 / count) * 100;

            console.log(`${p1Percent.toFixed(2)}%`);
            console.log(`${p2Percent.toFixed(2)}%`);
            console.log(`${p3Percent.toFixed(2)}%`);
}