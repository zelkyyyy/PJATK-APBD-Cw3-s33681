using System.Data;
using LinqConsoleLab.PL.Data;

namespace LinqConsoleLab.PL.Exercises;

public sealed class ZadaniaLinq
{
    /// <summary>
    /// Zadanie:
    /// Wyszukaj wszystkich studentów mieszkających w Warsaw.
    /// Zwróć numer indeksu, pełne imię i nazwisko oraz miasto.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko, Miasto
    /// FROM Studenci
    /// WHERE Miasto = 'Warsaw';
    /// </summary>
    public IEnumerable<string> Zadanie01_StudenciZWarszawy()
    {
        // throw Niezaimplementowano(nameof(Zadanie01_StudenciZWarszawy));
        return DaneUczelni.Studenci.Where(e => e.Miasto == "Warsaw").Select(e => $"{e.NumerIndeksu} {e.Imie} {e.Nazwisko} {e.Miasto}");
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj listę adresów e-mail wszystkich studentów.
    /// Użyj projekcji, tak aby w wyniku nie zwracać całych obiektów.
    ///
    /// SQL:
    /// SELECT Email
    /// FROM Studenci;
    /// </summary>
    public IEnumerable<string> Zadanie02_AdresyEmailStudentow()
    {
        // throw Niezaimplementowano(nameof(Zadanie02_AdresyEmailStudentow));
        return DaneUczelni.Studenci.Select(e => e.Email);
    }

    /// <summary>
    /// Zadanie:
    /// Posortuj studentów alfabetycznie po nazwisku, a następnie po imieniu.
    /// Zwróć numer indeksu i pełne imię i nazwisko.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko
    /// FROM Studenci
    /// ORDER BY Nazwisko, Imie;
    /// </summary>
    public IEnumerable<string> Zadanie03_StudenciPosortowani()
    {
        // throw Niezaimplementowano(nameof(Zadanie03_StudenciPosortowani));
        return DaneUczelni.Studenci.OrderBy(e => e.Nazwisko).ThenBy(e => e.Imie).Select(e => $"{e.NumerIndeksu} {e.Imie} {e.Nazwisko}");
    }

    /// <summary>
    /// Zadanie:
    /// Znajdź pierwszy przedmiot z kategorii Analytics.
    /// Jeżeli taki przedmiot nie istnieje, zwróć komunikat tekstowy.
    ///
    /// SQL:
    /// SELECT TOP 1 Nazwa, DataStartu
    /// FROM Przedmioty
    /// WHERE Kategoria = 'Analytics';
    /// </summary>
    public IEnumerable<string> Zadanie04_PierwszyPrzedmiotAnalityczny()
    {
        // throw Niezaimplementowano(nameof(Zadanie04_PierwszyPrzedmiotAnalityczny));
        var x = DaneUczelni.Przedmioty.FirstOrDefault(e => e.Kategoria == "Analytics");
        if (x != null)
            return [$"{x.Nazwa} {x.DataStartu}"];
        else
            return ["Taki przedmiot nie istnieje"];
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy w danych istnieje przynajmniej jeden nieaktywny zapis.
    /// Zwróć jedno zdanie z odpowiedzią True/False albo Tak/Nie.
    ///
    /// SQL:
    /// SELECT CASE WHEN EXISTS (
    ///     SELECT 1
    ///     FROM Zapisy
    ///     WHERE CzyAktywny = 0
    /// ) THEN 1 ELSE 0 END;
    /// </summary>
    public IEnumerable<string> Zadanie05_CzyIstniejeNieaktywneZapisanie()
    {
        // throw Niezaimplementowano(nameof(Zadanie05_CzyIstniejeNieaktywneZapisanie));
        var x = DaneUczelni.Zapisy.Any(e => !e.CzyAktywny);
        if (x)
            return ["Tak"];
        else
            return ["Nie"];
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy każdy prowadzący ma uzupełnioną nazwę katedry.
    /// Warto użyć metody, która weryfikuje warunek dla całej kolekcji.
    ///
    /// SQL:
    /// SELECT CASE WHEN COUNT(*) = COUNT(Katedra)
    /// THEN 1 ELSE 0 END
    /// FROM Prowadzacy;
    /// </summary>
    public IEnumerable<string> Zadanie06_CzyWszyscyProwadzacyMajaKatedre()
    {
        // throw Niezaimplementowano(nameof(Zadanie06_CzyWszyscyProwadzacyMajaKatedre));
        var x = DaneUczelni.Prowadzacy.All(e => !string.IsNullOrEmpty(e.Katedra));
        if (x)
            return ["Tak"];
        else
            return ["Nie"];
    }

    /// <summary>
    /// Zadanie:
    /// Policz, ile aktywnych zapisów znajduje się w systemie.
    ///
    /// SQL:
    /// SELECT COUNT(*)
    /// FROM Zapisy
    /// WHERE CzyAktywny = 1;
    /// </summary>
    public IEnumerable<string> Zadanie07_LiczbaAktywnychZapisow()
    {
        // throw Niezaimplementowano(nameof(Zadanie07_LiczbaAktywnychZapisow));
        return [$"{DaneUczelni.Zapisy.Count(e => e.CzyAktywny)}"];
    }

    /// <summary>
    /// Zadanie:
    /// Pobierz listę unikalnych miast studentów i posortuj ją rosnąco.
    ///
    /// SQL:
    /// SELECT DISTINCT Miasto
    /// FROM Studenci
    /// ORDER BY Miasto;
    /// </summary>
    public IEnumerable<string> Zadanie08_UnikalneMiastaStudentow()
    {
        // throw Niezaimplementowano(nameof(Zadanie08_UnikalneMiastaStudentow));
        return DaneUczelni.Studenci.Select(e=>e.Miasto).Distinct().OrderBy(e => e);
    }

    /// <summary>
    /// Zadanie:
    /// Zwróć trzy najnowsze zapisy na przedmioty.
    /// W wyniku pokaż datę zapisu, identyfikator studenta i identyfikator przedmiotu.
    ///
    /// SQL:
    /// SELECT TOP 3 DataZapisu, StudentId, PrzedmiotId
    /// FROM Zapisy
    /// ORDER BY DataZapisu DESC;
    /// </summary>
    public IEnumerable<string> Zadanie09_TrzyNajnowszeZapisy()
    {
        // throw Niezaimplementowano(nameof(Zadanie09_TrzyNajnowszeZapisy));
        return DaneUczelni.Zapisy.OrderByDescending(e => e.DataZapisu).Take(3).Select(e => $"{e.DataZapisu} {e.StudentId} {e.PrzedmiotId}");
    }

    /// <summary>
    /// Zadanie:
    /// Zaimplementuj prostą paginację dla listy przedmiotów.
    /// Załóż stronę o rozmiarze 2 i zwróć drugą stronę danych.
    ///
    /// SQL:
    /// SELECT Nazwa, Kategoria
    /// FROM Przedmioty
    /// ORDER BY Nazwa
    /// OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;
    /// </summary>
    public IEnumerable<string> Zadanie10_DrugaStronaPrzedmiotow()
    {
        // throw Niezaimplementowano(nameof(Zadanie10_DrugaStronaPrzedmiotow));
        return DaneUczelni.Przedmioty.OrderBy(e => e.Nazwa).Skip(2).Take(2).Select(e => $"{e.Nazwa} {e.Kategoria}");
    }

    /// <summary>
    /// Zadanie:
    /// Połącz studentów z zapisami po StudentId.
    /// Zwróć pełne imię i nazwisko studenta oraz datę zapisu.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, z.DataZapisu
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId;
    /// </summary>
    public IEnumerable<string> Zadanie11_PolaczStudentowIZapisy()
    {
        // throw Niezaimplementowano(nameof(Zadanie11_PolaczStudentowIZapisy));
        return DaneUczelni.Studenci.Join(DaneUczelni.Zapisy, e => e.Id, e => e.StudentId,
            (student, zapis) => $"{student.Imie} {student.Nazwisko} {zapis.DataZapisu}");
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj wszystkie pary student-przedmiot na podstawie zapisów.
    /// Użyj podejścia, które pozwoli spłaszczyć dane do jednej sekwencji wyników.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, p.Nazwa
    /// FROM Zapisy z
    /// JOIN Studenci s ON s.Id = z.StudentId
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId;
    /// </summary>
    public IEnumerable<string> Zadanie12_ParyStudentPrzedmiot()
    {
        // throw Niezaimplementowano(nameof(Zadanie12_ParyStudentPrzedmiot));
        return DaneUczelni.Zapisy
            .Join(DaneUczelni.Studenci, p => p.StudentId, z => z.Id, (zapis, student) => new { zapis, student })
            .Join(DaneUczelni.Przedmioty, temp => temp.zapis.PrzedmiotId, p => p.Id, (temp, przedmiot)=>$"{temp.student.Imie} {temp.student.Nazwisko} {przedmiot.Nazwa}");
    }

    /// <summary>
    /// Zadanie:
    /// Pogrupuj zapisy według przedmiotu i zwróć nazwę przedmiotu oraz liczbę zapisów.
    ///
    /// SQL:
    /// SELECT p.Nazwa, COUNT(*)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie13_GrupowanieZapisowWedlugPrzedmiotu()
    {
        // throw Niezaimplementowano(nameof(Zadanie13_GrupowanieZapisowWedlugPrzedmiotu));
        return DaneUczelni.Zapisy
            .Join(DaneUczelni.Przedmioty, x => x.PrzedmiotId, x => x.Id, (zapis, przedmiot) => new { zapis, przedmiot })
            .GroupBy(p => p.przedmiot.Nazwa).Select(e => $"{e.Key} {e.Count()}");
    }

    /// <summary>
    /// Zadanie:
    /// Oblicz średnią ocenę końcową dla każdego przedmiotu.
    /// Pomiń rekordy, w których ocena końcowa ma wartość null.
    ///
    /// SQL:
    /// SELECT p.Nazwa, AVG(z.OcenaKoncowa)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie14_SredniaOcenaNaPrzedmiot()
    {
        // throw Niezaimplementowano(nameof(Zadanie14_SredniaOcenaNaPrzedmiot));
        return DaneUczelni.Zapisy
            .Join(DaneUczelni.Przedmioty, zapis => zapis.PrzedmiotId, przedmiot => przedmiot.Id
                , (zapis, przedmiot) => new { zapis, przedmiot })
            .Where(temp => temp.zapis.OcenaKoncowa != null)
            .GroupBy(temp => temp.przedmiot.Nazwa)
            .Select(grupa => $"{grupa.Key}: {grupa.Average(g => g.zapis.OcenaKoncowa)}");
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego prowadzącego policz liczbę przypisanych przedmiotów.
    /// W wyniku zwróć pełne imię i nazwisko oraz liczbę przedmiotów.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, COUNT(p.Id)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie15_ProwadzacyILiczbaPrzedmiotow()
    {
        // throw Niezaimplementowano(nameof(Zadanie15_ProwadzacyILiczbaPrzedmiotow));
        return DaneUczelni.Prowadzacy
            .Join(DaneUczelni.Przedmioty, p => p.Id, p => p.ProwadzacyId
                , (prowadzacy, przedmiot) => new { prowadzacy, przedmiot })
            .GroupBy(temp => new {temp.prowadzacy.Imie, temp.prowadzacy.Nazwisko})
            .Select(e => $"{e.Key.Imie} {e.Key.Nazwisko} {e.Count()}");
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego studenta znajdź jego najwyższą ocenę końcową.
    /// Pomiń studentów, którzy nie mają jeszcze żadnej oceny.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, MAX(z.OcenaKoncowa)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY s.Imie, s.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie16_NajwyzszaOcenaKazdegoStudenta()
    {
        // throw Niezaimplementowano(nameof(Zadanie16_NajwyzszaOcenaKazdegoStudenta));
        return DaneUczelni.Studenci
            .Join(DaneUczelni.Zapisy, e => e.Id, e => e.StudentId, (student, zapis) => new {student, zapis})
            .Where(e => e.zapis.OcenaKoncowa != null)
            .GroupBy(e => new {e.student.Imie, e.student.Nazwisko})
            .Select(e => $"{e.Key.Imie} {e.Key.Nazwisko} {e.Max(x => x.zapis.OcenaKoncowa)}");
    }

    /// <summary>
    /// Wyzwanie:
    /// Znajdź studentów, którzy mają więcej niż jeden aktywny zapis.
    /// Zwróć pełne imię i nazwisko oraz liczbę aktywnych przedmiotów.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Imie, s.Nazwisko
    /// HAVING COUNT(*) > 1;
    /// </summary>
    public IEnumerable<string> Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem()
    {
        // throw Niezaimplementowano(nameof(Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem));
        return DaneUczelni.Studenci
            .Join(DaneUczelni.Zapisy, z => z.Id, z => z.StudentId, (student, zapis) => new { student, zapis })
            .Where(e => e.zapis.CzyAktywny)
            .GroupBy(e => new {e.student.Imie, e.student.Nazwisko})
            .Where(e => e.Count() > 1)
            .Select(e => $"{e.Key.Imie} {e.Key.Nazwisko} {e.Count()}");
    }

    /// <summary>
    /// Wyzwanie:
    /// Wypisz przedmioty startujące w kwietniu 2026, dla których żaden zapis nie ma jeszcze oceny końcowej.
    ///
    /// SQL:
    /// SELECT p.Nazwa
    /// FROM Przedmioty p
    /// JOIN Zapisy z ON p.Id = z.PrzedmiotId
    /// WHERE MONTH(p.DataStartu) = 4 AND YEAR(p.DataStartu) = 2026
    /// GROUP BY p.Nazwa
    /// HAVING SUM(CASE WHEN z.OcenaKoncowa IS NOT NULL THEN 1 ELSE 0 END) = 0;
    /// </summary>
    public IEnumerable<string> Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych()
    {
        // throw Niezaimplementowano(nameof(Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych));
        return DaneUczelni.Przedmioty
            .Join(DaneUczelni.Zapisy, e=> e.Id, zapis => zapis.PrzedmiotId, (przedmiot, zapis) => new {przedmiot, zapis})
            .Where(temp => temp.przedmiot.DataStartu.Month == 4 && temp.przedmiot.DataStartu.Year == 2026)
            .GroupBy(e => e.przedmiot.Nazwa)
            .Where(g => g.All(x => x.zapis.OcenaKoncowa == null))
            .Select(e => $"{e.Key}");
    }

    /// <summary>
    /// Wyzwanie:
    /// Oblicz średnią ocen końcowych dla każdego prowadzącego na podstawie wszystkich jego przedmiotów.
    /// Pomiń brakujące oceny, ale pozostaw samych prowadzących w wyniku.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, AVG(z.OcenaKoncowa)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// LEFT JOIN Zapisy z ON z.PrzedmiotId = p.Id
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach()
    {
        // throw Niezaimplementowano(nameof(Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach));
        return DaneUczelni.Prowadzacy
            .Join(DaneUczelni.Przedmioty, p => p.Id, p => p.ProwadzacyId, (prowadzacy, przedmiot) => new {prowadzacy, przedmiot})
            .Join(DaneUczelni.Zapisy, e => e.przedmiot.Id, zapis => zapis.PrzedmiotId, (temp, zapis) => new {temp, zapis})
            .Where(e => e.zapis.OcenaKoncowa != null)
            .GroupBy(e => new {e.temp.prowadzacy.Imie, e.temp.prowadzacy.Nazwisko})
            .Select(e => $"{e.Key.Imie} {e.Key.Nazwisko} {e.Average(e => e.zapis.OcenaKoncowa)}");
    }

    /// <summary>
    /// Wyzwanie:
    /// Pokaż miasta studentów oraz liczbę aktywnych zapisów wykonanych przez studentów z danego miasta.
    /// Posortuj wynik malejąco po liczbie aktywnych zapisów.
    ///
    /// SQL:
    /// SELECT s.Miasto, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Miasto
    /// ORDER BY COUNT(*) DESC;
    /// </summary>
    public IEnumerable<string> Wyzwanie04_MiastaILiczbaAktywnychZapisow()
    {
        // throw Niezaimplementowano(nameof(Wyzwanie04_MiastaILiczbaAktywnychZapisow));
        return DaneUczelni.Studenci
            .Join(DaneUczelni.Zapisy, stud => stud.Id, zapis => zapis.StudentId, (student, zapis) => new {student, zapis})
            .Where(z => z.zapis.CzyAktywny)
            .GroupBy(s => s.student.Miasto)
            .OrderByDescending(e => e.Count())
            .Select(e => $"{e.Key} {e.Count()}");;
    }

    private static NotImplementedException Niezaimplementowano(string nazwaMetody)
    {
        return new NotImplementedException(
            $"Uzupełnij metodę {nazwaMetody} w pliku Exercises/ZadaniaLinq.cs i uruchom polecenie ponownie.");
    }
}
