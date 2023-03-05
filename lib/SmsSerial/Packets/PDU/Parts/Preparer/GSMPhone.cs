namespace Sms.Payload.PDU.Parts.Preparer
{
    internal static class GSMPhone
    {
        private static bool NotValidScaPhone(string value) =>
                 value[0] != '7' & value[0] != '+' & value[0] != '8';

        public static string GenerateGSMPhone(this string value)
        {
            if (NotValidScaPhone(value)) return string.Empty;
            return PrepareResult(value);
        }

        private static string PrepareResult(string value)
        {
            List<char> p = PrepareToInternationalFormat(value);
            RearrangeAdjacentCharacters(ref p);
            var result = new string(p.ToArray());
            return result;
        }

        private static void RearrangeAdjacentCharacters(ref List<char> p)
        {
            for (int i = 0; i < p.Count(); i += 2)
            {
                var temp = p[i];
                p[i] = p[i + 1];
                p[i + 1] = temp;
            }
        }

        private static List<char> PrepareToInternationalFormat(string phone)
        {
            var p = phone.ToList();
            if (p.Contains('+')) p.Remove('+');
            if (p[0] == '8') p[0] = '7';
            if (p.Count() % 2 != 0) p.Add('F');
            return p;
        }
    }
}
