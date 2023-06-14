using System;
using System.Threading;

namespace Joint_Petition_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // The options to display to the user
            string[] options = {
            "Represented - After 7/1/2019",
            "Unrepresented (Pro se) - After 7/1/2019",
            "Represented & Own Risk - After 7/1/2019",
            "Unrepresented (Pro se) & Own Risk - After 7/1/2019",
            "Represented - Before 7/1/2019",
            "Unrepresented (Pro se) - Before 7/1/2019",
            "Represented & Own Risk - Before 7/1/2019",
            "Unrepresented (Pro se) & Own Risk - Before 7/1/2019" };

            // The index of the currently selected option
            int selectedIndex = 0;

            // Flag to indicate if the user is done making selections
            bool done = false;

            // Keep running the program until the user is done
            while (!done)
            {
                // Clear the console before displaying the options
                Console.Clear();

                // Display the options
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                // Wait for user input
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                // Determine what action to take based on the key the user pressed
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        // If the user pressed the up arrow key, move the selection up
                        selectedIndex = selectedIndex - 1 < 0 ? options.Length - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        // If the user pressed the down arrow key, move the selection down
                        selectedIndex = (selectedIndex + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        // If the user pressed the enter key, they are done making a selection
                        done = true;
                        break;
                }
            }

            // Clear the console and display the selected option
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(options[selectedIndex]);
            Console.ResetColor();
            Console.WriteLine("What is the Settlement Amount?");
            double settlementAmt = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n *** COPY BELOW THIS ONLY *** \n");
            string output = "";
            switch (options[selectedIndex])
            {
                case "Represented - After 7/1/2019":
                    double attyFee = 0;
                    double MITFTax = 0;
                    double OSHATax = 0;
                    double ownRiskTax = 0;
                    attyFee = settlementAmt * .2;
                    MITFTax = settlementAmt * .03;
                    OSHATax = settlementAmt * .0075;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} ({settlementAmt.ToString("C")} x .20 = {attyFee.ToString("C")})\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} ({settlementAmt.ToString("C")} x .03 = {MITFTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant and Their Attorney {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(MITFTax + OSHATax).ToString("C")} (MITF Tax + OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. NEVER mail any check directly to the claimant since their attorney " +
                        $"may have expenses that they take out of the check. If you have any questions please contact us. Thanks";
                    break;
                case "Unrepresented (Pro se) - After 7/1/2019":
                    attyFee = settlementAmt * 0;
                    MITFTax = settlementAmt * .03;
                    OSHATax = settlementAmt * .0075;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} (Unrepresented/Pro se)\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} ({settlementAmt.ToString("C")} x .03 = {MITFTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(MITFTax + OSHATax).ToString("C")} (MITF Tax + OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. If you have any questions please contact us. Thanks";
                    break;
                case "Represented & Own Risk - After 7/1/2019":
                    attyFee = settlementAmt * .2;
                    MITFTax = settlementAmt * .03;
                    OSHATax = settlementAmt * .0075;
                    ownRiskTax = settlementAmt * .02;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} ({settlementAmt.ToString("C")} x .20 = {attyFee.ToString("C")})\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} ({settlementAmt.ToString("C")} x .03 = {MITFTax.ToString("C")})\n" +
                        $"Own Risk Tax = {ownRiskTax.ToString("C")} ({settlementAmt.ToString("C")} x .02 = {ownRiskTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant and Their Attorney {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(MITFTax + OSHATax).ToString("C")} (MITF Tax + OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. NEVER mail any check directly to the claimant since their attorney " +
                        $"may have expenses that they take out of the check. If you have any questions please contact us. Thanks";
                    break;
                case "Unrepresented (Pro se) & Own Risk - After 7/1/2019":
                    attyFee = settlementAmt * 0;
                    MITFTax = settlementAmt * .03;
                    OSHATax = settlementAmt * .0075;
                    ownRiskTax = settlementAmt * .02;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} (Unrepresented/Pro se)\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} ({settlementAmt.ToString("C")} x .03 = {MITFTax.ToString("C")})\n" +
                        $"Own Risk Tax = {ownRiskTax.ToString("C")} ({settlementAmt.ToString("C")} x .02 = {ownRiskTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(MITFTax + OSHATax + ownRiskTax).ToString("C")} (MITF Tax + OSHA Tax + Own Risk Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. If you have any questions please contact us. Thanks";
                    break;
                case "Represented - Before 7/1/2019":
                    attyFee = settlementAmt * .2;
                    MITFTax = settlementAmt * 0;
                    OSHATax = settlementAmt * .0075;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} ({settlementAmt.ToString("C")} x .20 = {attyFee.ToString("C")})\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} (Before 7/1/2019)\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant and Their Attorney {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {OSHATax.ToString("C")} (OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. NEVER mail any check directly to the claimant since their attorney " +
                        $"may have expenses that they take out of the check. If you have any questions please contact us. Thanks";
                    break;
                case "Unrepresented (Pro se) - Before 7/1/2019":
                    attyFee = settlementAmt * 0;
                    MITFTax = settlementAmt * 0;
                    OSHATax = settlementAmt * .0075;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} (Unrepresented/Pro se)\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} (Before 7/1/2019)\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {OSHATax.ToString("C")} (OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. If you have any questions please contact us. Thanks";
                    break;
                case "Represented & Own Risk - Before 7/1/2019":
                    attyFee = settlementAmt * .2;
                    MITFTax = settlementAmt * 0;
                    OSHATax = settlementAmt * .0075;
                    ownRiskTax = settlementAmt * .02;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} ({settlementAmt.ToString("C")} x .20 = {attyFee.ToString("C")})\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} (Before 7/1/2019)\n" +
                        $"Own Risk Tax = {ownRiskTax.ToString("C")} ({settlementAmt.ToString("C")} x .02 = {ownRiskTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant and Their Attorney {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(ownRiskTax + OSHATax).ToString("C")} (Own Risk Tax + OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. NEVER mail any check directly to the claimant since their attorney " +
                        $"may have expenses that they take out of the check. If you have any questions please contact us. Thanks";
                    break;
                case "Unrepresented (Pro se) & Own Risk - Before 7/1/2019":
                    attyFee = settlementAmt * 0;
                    MITFTax = settlementAmt * 0;
                    OSHATax = settlementAmt * .0075;
                    ownRiskTax = settlementAmt * .02;
                    output = $"Settlement Amount = {settlementAmt.ToString("C")}\n" +
                        $"Attorney Fee = {attyFee.ToString("C")} (Unrepresented/Pro se)\n" +
                        $"MITF Tax = {MITFTax.ToString("C")} (Before 7/1/2019)\n" +
                        $"Own Risk Tax = {ownRiskTax.ToString("C")} ({settlementAmt.ToString("C")} x .02 = {ownRiskTax.ToString("C")})\n" +
                        $"OSHA Tax = {OSHATax.ToString("C")} ({settlementAmt.ToString("C")} x .0075 = {OSHATax.ToString("C")})\n\n" +
                        $"Check breakdown- Make checks payable to:\n\n" +
                        $"Claimant {(settlementAmt - MITFTax).ToString("C")} ({settlementAmt.ToString("C")} - {MITFTax.ToString("C")})\n" +
                        $"Oklahoma Tax Commission {(ownRiskTax + OSHATax).ToString("C")} (Own Risk Tax + OSHA Tax)\n" +
                        $"Oklahoma Worker's Compensation Commission $140 Filing Fee (Unless already paid)\n\n" +
                        $"Please double-check the math. A wise person once said, \"Better to measure twice and cut once\". Also, check for any child support liens. " +
                        $"We recommend mailing all the checks here to be cataloged and dispersed. If you have any questions please contact us. Thanks";
                    break;

            }
            Console.WriteLine(output);
            Console.WriteLine("\n *** COPY ABOVE THIS ONLY ***");
            Console.ReadKey();
        }
    }
}
