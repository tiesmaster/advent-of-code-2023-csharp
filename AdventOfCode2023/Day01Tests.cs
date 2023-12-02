using System;

using Xunit;

namespace AdventOfCode2023;

public class Day01Tests
{
    private int Day01Part1(string input)
    {
        var calibrationValues = ParseCalibrationValues(input);
        return calibrationValues.Sum();
    }
    private int Day01Part2(string input)
    {
        var calibrationValues = ParseCalibrationValuesWithImprovedParsing(input);
        return calibrationValues.Sum();
    }

    private static IEnumerable<int> ParseCalibrationValues(string input)
    {
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            var digitChars = line.Where(char.IsDigit);

            var s = digitChars.First();
            var e = digitChars.Last();

            yield return int.Parse(s.ToString() + e.ToString());
        }
    }

    private static IEnumerable<int> ParseCalibrationValuesWithImprovedParsing(string input)
    {
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            var digitChars = Tokenize(line);

            var d1 = digitChars.First();
            var d2 = digitChars.Last();

            yield return (10 * d1) + d2;
        }

        static IEnumerable<int> Tokenize(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    yield return c;
                }
                else if (true)
                {


                }

            }
        }
    }

    [Fact]
    public void Part1Test()
    {
        var input = """
            1abc2
            pqr3stu8vwx
            a1b2c3d4e5f
            treb7uchet
            """;

        var result = Day01Part1(input);

        result.Should().Be(142);
    }

    [Fact]
    public void Part1TestParsedValues()
    {
        var input = """
            1abc2
            pqr3stu8vwx
            a1b2c3d4e5f
            treb7uchet
            """;

        var result = ParseCalibrationValues(input);

        result.Should().BeEquivalentTo([12, 38, 15, 77]);
    }

    [Fact]
    public void Part1()
    {
        var input = RealDealValue;

        var result = Day01Part1(input);

        result.Should().Be(56397);
    }

    [Fact]
    public void Part2Test()
    {
        var input = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """;

        var result = Day01Part2(input);

        result.Should().Be(281);
    }

    [Fact]
    public void Part2TestParsedValues()
    {
        var input = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """;

        var result = ParseCalibrationValuesWithImprovedParsing(input);

        result.Should().BeEquivalentTo([29, 83, 13, 24, 42, 14, 76]);
    }

    [Fact]
    public void Part2()
    {
        var input = RealDealValue;

        var result = Day01Part2(input);

        result.Should().Be(666);
    }

    private static string RealDealValue => """
            nqninenmvnpsz874
            8twofpmpxkvvdnpdnlpkhseven4ncgkb
            six8shdkdcdgseven8xczqrnnmthreecckfive
            qlcnz54dd75nine7jfnlfgz
            7vrdhggdkqbnltlgpkkvsdxn2mfpghkntzrhtjgtxr
            cdhmktwo6kjqbprvfour8
            ninekkvkeight9three
            ms9five71lrfpqxqlbj
            9five9sevenldshqfgcnq
            1one4seven
            7qtg3jmnd1two2
            2c7four8one
            qdkneight6zqcrgxxnkjdbb
            twofourjqnpv4lgvzjzgnn
            pgmmmcvcrmxsevenfour1three1threexx
            nbcmmrx7eight923
            5eightr9threemmdtp
            ninedbrone2
            onethreesixtwozkqbmsixfivefour5
            68eightkznineonethree2pdrgrx
            9four2pjdxgbsxddpkfqjqrtzt
            dbtrsnscpztworfgdjrctwo2one9
            2gssvcnnsmlsixthree7onedmdpnjh6
            xkpd23four1seven8six
            ldz638mfpnclztdjkns
            hrjtvdtb9ninedhzxdsskd
            nhpscgrrtqdsixfive9f9
            sixkzqqznmmcqqxninepdqbf8nine
            1six52six1
            6frronepkgmsjgtzlbcveight
            threejctzbkxbone7six
            1fiverqvpjvdbzfjhjzpsttbglqtfvcqpbcgpkvkn
            vjfd8ninekt9qjr
            16fivefivesixtsmpkzv9
            ffxcxcm5qrkgxnmkgxnmhzkrssjtjrmnvltsfmh
            6fourvkxzlxfjqcxv
            sixjxpqjtcrtsixjtwo1
            eightnine2jqnqvznkrbrmcthree6
            3tzlfqvhxdjbtlntvlfm73rnjhmznstfgqcncjbj
            fiveclspv3dlbvlp
            sevenfourck6kdqstmone
            dmqvplslvxgbd2
            2lzjmlpfccgnlqfive
            twoone6one
            eightmngshxdvnine3vjlpncmqtq
            1sttwo4
            stwone3dzjhlxg
            oneninecszxmffctwo9eight
            5three5xnhgtgrmvthree6onefkxjhglr1
            88onethreenxthhbqs9ljnpbmh3
            fqbxgjsts85qp3
            nine9five8one4bff
            four65ltqsixqmmml9
            bhjpcfzvtczhn1four
            1threet23
            eight5threetwo1
            23nine1kbvgbthjnnineonetjqbflrfg8
            11qthreelvjfive1
            fiveqthreenine3sscz81jbccdnhdmz
            9tvclcptc3
            lrtlblzj2lpbgvmzgx
            8zfmctx2
            one8lkseven2eightcxqvd6
            7one7hqjhkgzqzs
            3qlgq
            phkchcpdcm7jtg3rfive
            ffbcrneightvhzcckq1
            3hlgrdsdsplnhpc
            1vbdxqnzrthree
            seven93six25sixnine
            four1bxstchgzjdpxdninedpfour4
            65fivetnsseight8lcvgkkglslcjtjssxmgtvk
            fourjqgvkdkl2pxseven2ninemzqfqv
            zqmsbltpvsrzcpnn2twolzdjqmb88
            3qnzkmbltldthreesix1ffive36
            kspfzvvvfkztcs9threefoureightsixseveneight
            gh234r
            vqtrnskhkl658
            6five7mscjtxlrhc
            nsxjptfkjfsbm4fivefv
            two3eightmtldcxpvfourfive2
            zdbfourmchtdonefiveqpqlxn5bjhzdhz
            7lnqgone3fivehtmbj6nine
            fjkvmgvfgqbfivezdnlxmfzbdjbdvqrj2nine
            glpxlb6rq7fourone
            three4sixjxg
            fourgqcmtqhpvnscb9rvkdhmltnkxvhmcg
            gbjqshjktddkhkdfckqfivenine471
            bltthrp2seven4rqzgklsthleightlljczbeight4
            xsmbv3nine1nine7
            hdcdsgk59eightbstcgprslsxxflcn
            2mmjhsqstdhrstwothreeonetwoh
            xpsevenfiveseven2fourthree78
            8vscrfbxdq4kqjgsbffddr
            eight5xbjdqjrxs93
            3tseven
            svninetjflvqngqp1pgvmrqvgfour
            2ggrqtnzsrsevenmfqjgd
            qznhctbxb1
            vpcpgsh9hdhvdnhkdqtzc3six7
            vbtwonebffmphmxdeighttwo6sevenrvsqjthree
            four74
            1threeeightnsp5
            ftxj99twotwo5
            9onesevenqcsjrpp
            27556sqnpjnnddn
            cffxtjssdbrdseven7
            kxdlzldpkrsffourfsnrcstllxvjnbnqnstchlvrbxpx4
            33knb
            8mkcmxctcf3
            ninexzhtqsr6hnftrbbnsevensevenoneightq
            fourfour9fivetwo4
            62gmqjsvthg
            tbdkbchcmb7
            38xztpsx18xcmcdqtmg
            rrxb73six6
            2943four2onephbj
            txknhkn8
            qkfmptsqrchbdhgr3vphrkmz
            one2prbchjsskj45zmnlbrdkk
            ninefive7eight633
            qjc3threefour8
            858eightsevensix
            cthvxzxxqb4tknone5xfqprdzntj
            five8828mlmdfd
            threechljksevenninefttmkfsxvz98
            sixsixgckqtfvmxltdjthbtnjvmpxs6nine8
            eightsixnxdjg57sixmpseven
            1smpvbqkg
            rpgxfrlg3seven
            qvdseven3four7
            9nzmqq
            7nkbcglxgsixjgsbhkkr66
            54three
            eight8qjmvnptn4eight
            seven5fivett77six
            kfkngbkkjsqlk6foureight
            rz17
            seveneight4493845
            9vfhnzfourfourseventxfcxg
            vzsfqhbseven9gbmshxzsixfivedhcvfjjdcmnfzbxx
            3two8three
            twovg1ctxrm8three8kgckpfbm
            x2
            25nineeighttwoeight9fourfour
            27two583
            sixeight67fivecgbxbvrpghfzdzfkzptqlhq
            eight8rltgnb8cnrnjqggl
            fbprf9twonccnkkdf98eight
            sjzsjdfv3three15kjjjdnmfivevmcxtk
            xsrfvjblk2779
            fivednpgkqjl3five
            twolpeightgzcsix624llqdbrnnz
            jmoneightsevenpzxdsbzvmcvmmh733fourfourthree
            4eight1mmtqckvnxfour
            nine4jnnqxcsdsvxqnbvzxmf
            fourvzrhx52ntqpl99fljdhmtctcptgtck
            6rvtkmtjtzqrgltqltcjnseven
            srmkdxqdd2sevenrxht4
            2sixseven35sixseven4eightwoh
            9eightstdlrsjfndnxblsevennineeight
            ngvvqcfthreeccsfxtrh65four1
            416pgvmxbnpxbnjbxdk
            11eight23onefbszr
            72rvjkszv1four4foureight
            1sixrjkqsblbmtfive223vhh
            5fdbhxrkxbhfftwotn
            cpxchdmhjbn6s3sevennine
            nine528
            ninetwo623ln6qrhthcxvk
            67qlpfiveninesixh
            nine1cvzb55grhbdxrlgf13
            tqxztncjrlctfxqv7twofbfour35
            416
            4sevennnsixeight3one
            bqhpgqzppconetwotwo9jtqldmcs
            7nccq
            five2one46rglkpeightlrqtskcxr
            crgcgeightfive6m1sttjtqjprvdbgph
            z92lbqjcggv87fbsix3
            4fourfive2
            cdrvdqfivesixthree9qmpgzbmg69
            4zpnjx4zkgqkfxz
            m4trfc8
            pndnt7
            ninefour7tgmdg2two
            gffvxxzj876
            vzpqmrkxt318seven2
            lpkhnfbfrjhj7one
            kbkb6k
            vrlgtjgqzdqsxznlt2three3
            sqpnxgzqrp1dpfkm
            eight24dnsk5p
            37sevenhdjfgnp9
            7qskj
            913one
            8z2tlncgccsbdqdmt
            bzpfrpt9nfz
            one4tmf3eighteightdxcmjrhnsix
            4mtmzzn
            3fchqlmpshz4kx
            7tbhnbdbv
            1knflgddmtwogzjmzdvcmjz
            93873czmcfive
            7gdfskkmfzqvhcsgcfgcdsbnn7jclxnx
            652nine2ntrntwodzjnzm
            cbfvnsqlsjzvh2gcgfpbqmfndcksrzcrsdpvfour
            6mvqqz9pbfblmsixone
            tmn3oneeight515
            825fourgmcfbctnnrxsix48
            57fourpsneightnineqhqvd
            4662qgjdcpmg
            six3eight5sixsksgxhcxthree99
            threethreehjbghfourseven3
            1jdjzxlm8two8
            3fiveeightwomnz
            fivebfttsevenbxflcsnqnb9fiveseven3
            vbkdcnqlcj9seveneight3mcjtmlj2one
            dzrscnvpj16csxchgjvphrvnfjhxlx74nine3
            eight76mxmeight51
            smntfcjhdmr4
            six8mtwo65sczqxjsx
            kkzb66ninecnqhzvflrjhjhprnr6seven
            twoztzlfctwo73ctdksix5two
            five42xds8qdxnrrfour6fncfrbfp
            sqfbbqsix6five6five88
            vvcztfjrz38fourrdxggjdj
            twoeightthree5372five9
            nine5sixkscsn19
            foursix29mplvnvdlfldkzcvfour
            onesixtwovrktfkqznjrbvptwo46
            dcnhsvsdgzrbkqqcsx2onemxnpm1seveneight
            nbpnspvqmkbxnff7jttxslzq5cd
            9onetvonekhsn9mbpplnttg
            4onetwotwofivefivedsvvdlrnbm6
            cprfvbcrpttwoqrptsq2
            483four
            seven32ninetwotf1threepbghpmpj
            scfrfvrdhrlzxgqvrztcxmxzntpbone3threenfxb
            slnine2five
            69
            466vczmxdndg1nb72eightwos
            7cjdrthreecqztq
            21nine1zkmonedxkcdzjbxt
            8ncgsfour1four3sftqgjzn3
            nine175xgrqdqhrk
            n2251fourjqvktskn6
            tbbffonefhrvrvbzstkn53lbgvmgvxk5
            7fsmfjvclp
            8one487sixone
            16fivetwo
            fournpzbgbm4ktfzljstvgqlxhlb
            six1bjrpnxvsixtwo7hkcqvmzhvtx
            4dxmlvlcqvmmssgbxpkt713eight
            1qkdnjqsixqnhzrgzzninexgcqdmqnmr
            xfgctwofour9
            8smfive
            five79
            three5vllhhcpb
            1seveneightone1
            eight9five5vvxbfbmmb4hfhg4
            7bfourzkjdlgqseight
            15oneonesevenjhrtspkdnine6
            vrlprgnm4tppcsdtbtnninegtcktsd7
            xtwone4pvdzstrzjg
            1nine6
            fjvrdrfgxjjl16threefivefqdtcgffourfour
            5sevenmpdhkqgmbkzjxgmxqnzjblxfour3xcftlvnrtm
            sixk7qzjseveng
            6b
            three97
            3ninefmjrptbmzz8hdbhfgnsjqbdzlvpnvfourtwo
            rtwonefcfvtdblsmzjfiveninesixeight7rbnjk6
            jcxzrfc4dtzjszs
            seven7nine1twoqqxmhrqhrj
            xdgbtltctonebncjcdzmgcgqkgmddx9four
            4zzpszsevenfourseventkrkclmxp5nine
            7eight278nmmk
            7ninezxqdqc
            3jfxsxtwozltwo3
            six7tkzgnkgblsxhfkrxbhfttqninepjxfpmnhthree
            5fivegzlsblkd
            vc4kkrrnpqhvktvtvgbxxv2bqrzbfzc38seven
            9twoninefive2ffmfft3seven8
            644jjzz7
            xttlbjzonetwoldm9seventwoeightvsl
            geightwofourtwonine6
            6six26gkj2
            cqczz1dvhthree9three28six
            five6sevenrlqsv9ftptrx2
            nlkqjgtcrxsfgnrc7khkndqrzckdjsbncrtdhbhbd91one
            rvnmlpbjnj5lmr
            qqtwoxtwo1crtgqdd9four
            onesevenvchtfkbfkgzrhzhpsg3six
            three3nine31tjnjphs2mnz
            ninecszcvfn14eightthreedjhtxsrczjqgvpgm
            qqkgsrkhplfive61onenbpzxhm6t
            njgbzgvddqzdz4
            9two5eighttwoggrscndllxjsqhp2s
            seven417
            skgvnd5
            fzvlthreecrlqftlqvfh7
            seven6843sixnggrpk3
            sixxdmpcbfjp1bnq
            ninetgkhf3sixrnninebd
            eight3eight
            rbjvzeighttxqblqcdspxxhkhzfkrlmszgblqf2nine
            986qctmpblbx
            8three1seveneightone
            9pzzxg76
            3287sevennine8frpsgpnprtj
            2bfb6nineztzlqfbz
            9one1four
            sixfgmxklczhfbkkdfournine85
            zgc1c3kclrjdb4oneightpvp
            eight7threefnrggkvjd
            22fourxznjjjlfivefour
            8vvmcjcdtpnnd44
            cgdnsdnmq9lqmxdbl8five
            ckfqmnine9twofour2
            36onelkmfqp12kmvone
            79qsstc6tmmdjflqftwofivedvnlmkj
            sixb2six2
            9sixkbqhfive
            xhvsst4twoxvkrjgjtzs5bxgqhvrkrl
            foursz4
            three6mtdhqrjgbtwosjf
            threefourrrdfvzgngstwo783twotwo
            fmnccmdrrdtwoseven6
            tnktpgvgrgf2nine
            fivehkccqppjvbhkffour3
            8five6cksevenmqg
            fqm321six
            4twofour4
            xbeightxone5
            hnzfbzqhc8xnbssjpxnfour5
            seventwoddtnl93threetwo2
            nine36two37xxbszmhkc
            three4xkjqrpvhvqtb
            dtln7fivejfcgrxm5fivethtnfxl
            threeone8threethreetwo3jslhltsb
            8ninetwonnseventwoseveneightfour
            nine1rffvrkjpjdjzqnnrzqspqn
            oneninefourbrqrhljnxsggpsix8
            9kkgq4nine3seven
            4fivemldkdcxkszbjbm8qnhbhsixseven1
            jprktjkhp8
            threesixsixthree4
            lrtpddd5gmcgl
            ninejflqzhgkzcfour34
            sixeightvmqrgfmjrsf4jmcfqfpzxx
            qkrnqjbqpsvhc22nine9eightjx
            gvnine29sevenllzkqmg
            7one7rts8nine93
            46ninetwoztsbfgh
            6xjzrdvninesixjkhcs9
            lccxbmpplkl9fourthree7bhnssdone
            eight2oneoneonenine3jpz
            six2bsdvnhmzlmtdlbmt12eightsix
            nineone49pnkgdtfrqk
            zfivecxbmvb8dtpfhbxfour
            tjf97gbzfksdfmfzqvtjtd39four
            six49fourlnld
            4sevenone7
            9pnznzbktseven
            5262hgdzhhjdp4three
            seven3six68six
            qfdx92four2
            2xdfrdmd13lseven4mkz3
            threeonethreekmpstnineeighteight4eightwopt
            six1qhcdfmqslsxphtnxnonethree
            d7rprdfbzmj
            three8pzvgrmvq
            hgcvfttsztwo9eightwop
            mthreedhr78hxbzrzrmk7
            rfdbgxlxdccgmrlbglc9642fourthree
            eight9sevensevensix8ghhjnhqqsixkzzsg
            3jvqhs
            nnrpvtqvdgst68tltjjgnine1dr
            5fmldhrxfmqfourhkfqdlsphddzqxm8seven5one
            two5eightcdrnjmjjdbxrptmptxntwo
            54threehnlf5
            hvgshlg2dclxlvjfsneightsix
            44two2b
            9mcbjxjknzflvcklllxnllvfourfivefnzrvqtnjx8
            eight2hbknv6
            three3sevenpgh
            3dxgrslvqxbztkkxbhxfourfive9
            972skvkskj
            6xtkqrddn6shvtnmbxfrhjnmhnine
            9four6lxlbbfiveone9
            five6429
            6798one3sixjfive
            fxggjgckkjftwo7cqjgsz9lngfdr8six
            btdp9sixh1
            8threejhllninezzbrdhxxgqlszhnnhfsf9
            6twofbprcrrmvmgshsx9vcmxskpngbp
            9fivefivelnnsmnine
            p5zrcvkt2five
            lcjc9pfrfzfoursix2
            jjklqm1eight78onefour6
            3qpjqc59eight
            69mdnmptnl1
            five22
            2three5
            seven38nine
            four7zvc8drlvxzjfivetwo1
            1zhgcngbx4two
            6mhvbfkkrvsevenfoureightseven3
            d7dgsix3fivesevenvnqtvgl
            3hlrt1
            2kdtzxfive33
            xzrzjrkvsfqxcrjtl23eightone
            jcxxhvvddglmnqr8vxvj
            two5rbxsbgngcbfour
            8four56tmvqcccm1twosevenfour
            skhhxgrjh5vmvgpnqlbqvvz
            4tttnbkzjdvbgfpthtkt2xnine
            tfpdnineseven229
            5foursixone
            eight89nine8fjhbnzn675
            rvzbmc4eight1bbzfjcpq
            cpj1eightsevengpvmvgjpg1
            46xdsnvbmnine9212
            rhklrcb912czkkcvbbqc
            one22sevenp5
            7hmgfgmmr
            41sqhchvkz2qsrlcsmqgeightqdxlxtgkjdf
            gbtxgtrzz6fjffgvrddh
            m5threeoneonenine9
            foureightfive3zn
            9ninek6nfqrlrmhcg3five
            six3fqrvmrcrspsix7ptsseight
            2pqpqgppm63ccptb
            rtdsxdz53seveneightsixzbtrbbm
            8mpfnpgts75
            1one8pzcdhfive45eightgspms
            47mppvdxfmp
            nzjkpheightnine87two
            8threetwo1skqcg1two3
            4ftz7fourlzeightwodvh
            sevenzvjpfsnjgtc78two4fourone
            591zvdzpxtlgggsccrzb
            btwonesix66seven9three17xpxp
            nine66mhbn3djhhrcgcfsseven
            4twoeight
            9five3five
            1nine7eight
            mbvrdkqtnqeightxn751threedmrd
            nine1one
            eighttsffqxtq9ljshbsczj1bggsxgn
            cfivedtkkmnrzrbzxnm5
            kxzq362
            four51kzxrhhtqc9sixfjdjfivefive
            seventwoone4seven3sixsevenfive
            twoxrdhtdhxcvtmpv7tzr2two
            zblkqzptx93kqbrjlhdvbsdqeight
            18one68v
            2rhxdnccbnh31
            seven6dcbpgpnx
            22nine74sixzvmdbjnr7zmqgp
            7zlbjfmvb22eightpfjdcpf
            82nkckplqhmfourfourfmsixqpjdnpzht
            2onemftzcffcxl
            lqonethree464kvfnqzg
            9lsbonegzgkqhc3
            three4twoninexc
            2qtkpmmzcvjsqsttsevenfourpgp
            rfsz9tltpgfh4ncgcmzcvkssmjl7dhlpjdr
            kfivesixfivet8six
            gppsqngmmzdt16sevenbxnxqxsevensxnkqvtggbz
            qsldvhvcnj4j1jmlcjhkdkntbrdqch
            rlxnrbns6eightvcqmqrbdeighttjssrnvf1nine
            9sevennhtslbkfourq2
            9zgfnssevenngmsx8three
            9bkkqfhjzpc7vklvrkx
            qtwoc8six8
            fcvdseven95
            4threeseven
            two494
            twothree5one37sevenseven2
            4nxcnfiveeighttwoshjcqghjfx9one
            onefour9one
            four79kzn36
            23xck5smtkrzbqdc5
            3xcthreesixmtprspzdeightfnpgvpnfourtwo
            m5ksjbcnine7
            five1threegrgv522
            2fourfiveblxxzpgbntncpbqsxpztndx3
            st6
            3twohcpttzfcr36
            three9zhzglqcrhtstxzrdlxkl
            3two45
            3rqcqnxhctrseven3
            kmz7cxb9llmnctbnrf77eight
            rmghxpfzpktwo1twosmhcgzd9
            lpqknxtkq84
            cknbzcl5btmlzzrbxgponecfbvj1sevenms
            3jdvpb71sn9eightngpv
            7bthreeone
            kconeight6913sevenninenine2five
            eight924five1
            1onefivetwo
            xqdddcsj4
            bplrgcxfrb5twonine8threesixkfdvcfive
            nine9five7jlceightninetwo
            eightqpbmgjbcsevenbfnqeight48
            jt1vbsc
            klzrqpvdvnjhsevensix36
            fdt1rvr
            hhxhfivetvfvxqzjlcqdrgzlk2
            98three
            1259eight3twooneone
            threejxnffgl35five1
            7jvbnqhtwo75sgnine
            three31hcccbxknpgltnchp
            btjfdjkgvhlhkzsfptsbpmbx6four1
            79sonesevengvbbbltmdmfdbp6
            4sevenseven45qmthm85
            1rcflgtmfmmllljsfxbxnfour
            ssbjlfglgfcdzqs8onekrkhq6
            pknfvzxgmf35
            7sqkqqbtwonine4six
            seven1ptdbrxrptn
            tgbfxzzhqfnine4
            qbfgvpkz7twotv
            8nineqnmlsrzlfgfourthree
            onesix5ptmndhpbpnftdm8rxmhrqczptfdxz
            onesixnine77fdrscvmlmhptwovjdmvlx
            34twotfiveoneone4
            pstlglpjbxkjtlxn8foursixfbzfnvbzc26
            vrkdcsix4three19mnxftczrvhq
            sixjtg9two9rfourjpkzqfnqphsqpz
            pgfffmgr8kxjmsixsevenmzc5
            z3
            lh2hzkdqtgznknhdczseightkbzpc7eightzbr
            eightnineknhdxzst1
            615
            8tdxphfhmjtfourpljvmmsevenone
            ghxsrlf6mvmhd
            onepf8gdthreetwoeightmrfpmgdngeightoneightdr
            37fbvnqxpkk1165
            stkrqtqdphrtjg7zkcnmc2fourz
            six68sevenfive
            five7fiverpkmcjhjhvfnjjxcmbgv
            vhkmjlfgfxtkmqmcffour4
            seventhree6twosixdjnhd1
            fournineone7
            nrxtnmfstwodspstvjxfive8rb
            5onexchcrjkbxfmzcqlsfivesevendtwonercb
            four4two3
            fivetwolvzbjjhsone6nbnnine2hcpqhkdtc
            16four52fiveseventwo
            7pgksgsqmgeight
            bmltbvsone3onesixcgstfmfb2
            dvoneight8sevenseven
            5cgpnxxvjp8ninethree
            seventtqbmtwotwobblpcfkmnsbhhncbdxr7
            lkmlldgsthree2eightm17qfqjklpsbk
            kbhs54four137
            kljbrzflhmxnlfcfctcpkfnjtwosdk8fvzmgkrgzjfnlrzn
            4hrgzfjfourlvmps
            onexnskbm6mbkt
            threeqgjmchthree5zzkrtxfvshdtf
            ptvbq23jshqbdtbzdsmvone
            1nineeightsevenkc8sixfour
            jg1foursevensixtwobpxjvgb
            4ninepbbltwo
            clcx7jktrcftjone1seven
            cpgflmrcmnpjf2
            z9mrdbeight4nine51
            gkdrkvhctthh7four
            tddgpnineksbfnxfcdg13
            8seven2xpjjrsjq2
            p7hxnffff
            qnkhxznfzznr2fpqrvcczfksixjlctk
            8threenine3five9fiveone
            hslgtz3715fsseven
            qqoneightbbb9bfjxrddrdx2vcb
            1bcdhpjnsrgkgrd
            six6kvldqqkn
            6sevenhrltpblmpk5ninedjm
            hdgpmcrdnnzlplnpone8jtlhsdncchnfrk34kspgmvmf
            seven5hcz
            739
            hgsxrddmtqfour6ninenine
            eight8sixoneonenjtgtqbkj
            doneight5595eight2lztkfhz
            rxjhxzljgtnlkclfqchrhrlrgk8jr
            tq1fzfcjrhkslknrzg
            threethree5pkjnstfp
            npfsgghgk6cvvxmkxzjxcnztsntonexz56ctphqtg
            fivesnc66
            1bqkdfrr95
            5ktwoninekcjxqbr9vvhtfbdqbx
            nine2four3three74
            one9eight946
            six3lv
            onexbqzeight675oneghjlps
            9vhqtxfs
            lxdxcb79
            8seventwo1vktcvfzd1pbht
            1five72fftmlknntpvtbnzrthree9zlqblplmg
            81six93seven6ninehzm
            9nine27eightthree6f9eightwosg
            czptqdjg2k2ddsvqjq7
            511jklrccx
            371
            9zghjmlfbfkdthreexvtlzcsctwonineeight
            4twofbpjxrvgjfczglrqfhseven
            fivethree72sevenfour7three
            six9three92
            nlmzndltn2
            84sixninejtjgxq1fivelpmhhrbrm
            rzrp3three
            hxrvcmzbcvskthreeone2
            three6dkksxdfour1j
            68fz2four2twothvq9
            4fourrp65qgvktfivemqtbbmfcx
            joneight9nine
            lvclrzbrbhtcs8eightthreetkkpcnkzlnbxsffqq4
            fivehbblpjqttlhlpj5six51nkxqnjzhreight
            fstfdzzdseightone496
            fivetwoseven678
            six7htzlsx3ngtlthreethree
            threefmljmlcnftsm5jnjkdrjssix
            725zvpnsztlnqlhcnnmqkz6
            816
            xmvvxkbrzj8kj2one
            fourf9six
            4fiveljxvkbr
            sqjbrkgcnfm2zztm1
            lfcxxkdgzhonethreeseven5pxjgftn
            9cmprqhj8
            fstqjs6threefourthree
            seventhree1fsix
            921
            7three18vcxksonetjxnth7sbghvghdxt
            three4vb8
            9kxqbzxgrktwoonesgrkck
            fivefivesixseven91gbldflvdvcfvmjp
            81five76fqrxbkztgkctghrjjc
            deightwosix5oneqmjftdjhrqknxhrnf7dlmnine
            znzbpkjtqf36
            eightseven6nine7
            3jzdjbgznnscsbgnvpzm
            9xdjcclsevenfoursevenonedmflz1
            5pcqcchxsix662
            vfstwonelqlqxbxsgdczpfrshnkvsixndseven1
            93glfsdkzcnfourninemxmkzvqkl3nine
            nine72
            m2qtwo
            eight72
            eightz9114
            4fiveninevpp6tsmtdh
            eightsix7hfivenine
            ninefs7tkqgqrrmt3
            qltwone32sqshrmfglrm
            3twoxhdkhd5nine5sevensixzfvr
            4onenine
            lgtmhv41sevenrrpvxjjnvxmqpkmkqnine7two
            hdsltkbmnine93eight
            four4eight
            five2cgn5
            5one8
            gltnzbkpbnfournineeightdbv91frflzbqdnine
            oneppzkmsmzgdmbthkqbjpqnine3ctr1ptggbzght
            6ffhfponeninejxpjftwo
            nplmsninefive4dhfhjrc4fived
            4three56flbxxntg7six2frd
            7eightsevenfivem5
            4cq1htrrt
            vzqkhqddx1kdrgppgcvfqzsbtfseven5
            sevenjd9
            five5eightqhqrqcdzj3mzm5ddzcpg8
            nvhx8fourthree4
            xjpdjzdn5dltxnvqtkknvxsnqsmn7bzlgp7hdhbvn
            three1258sevengchvqkqcthreejltlljlf
            852
            eight98seven
            86fourone1two7dm
            fgr5rseventwo
            oneglvone99threefour
            3seven5sevenvd
            ccmzm5
            8ptpbgtteight7
            qrmszjb4two48brcbfrns
            tbzlcnx87five61
            fourxc1
            seven6sixfivenine
            9eight97lxkxzr
            ninefivefive1ffvthlldqhm
            4nine74jrfhk9
            77trlhtdpj75
            23eightbsmxkkfiveseven
            mbkpgfzs6kjlxxtjpxpmn
            sevenlxxlgmmhlxx6fjmonefive
            fivekprhbdmffr6twosixphphrfmmj6sixeight
            threefour5threefmsqgsconethreezqbctmvgt
            eightfoursevensix74rqzsjxncfrgpvjrzb1twoneds
            sixrrmcgnonegczjdzg8one
            23seven4zhshxgcgb
            3oneonefourfourncmxrqlpjnine
            v4
            ppzvseven5vdzspfzkxzqclzz17eight
            four83cffour
            7oneeightxmxsxt
            64vsxsxtqrbtwogxf5sgmz
            2kdtvfpcfxfive
            5hxtzhmrrgeight
            threesix46threesevenfour
            mgnine7three3fiveggdzvbcfpv
            7two7prhkcbmmmcmcmcchds1j
            eight1cxbsdxcdmksslxgfqg
            2ninethreexs467
            424twoninezncdzjsg
            8onethreekfdlfsjzzxslrjrzbqzjrkztsxq
            xfmdfourz5twozs
            163threeseventhree2
            gmqrjcngnp8dpbvhk53
            seveng3zqsix3fivefmqbjmfddn
            562hjlcmsddf1ngdpcnqdd
            7twoninefourfoursixplmcdzrvkgseven
            six4seven5zfjqtptxz6
            fngsfd2fiveone8eightthree
            3threeninethreethree
            ninefour29dxrnvqckjgchrljggvkgtj
            jmvprbdqdjbzb7six6fvrgh42
            3four854twothree8
            7hnfm
            lvxhprxxtvrzrkspd1fourthree
            ttsvjrltffvggshsvgc2threefivevg
            34krbnqzv6ltvsevenxkqjgtlddlpkcgtt
            lzkvcnine6
            91xdpone9threeeighttwo
            1vqznbgvgmljmfgtrnbcfseven
            four2ninekfrxthreethree2eighteight
            qslkxnljdcshx5
            8jtjrbgptgfoureightone5
            xkbninemc6bm
            six93nine54twonenb
            threer825mm996
            six1two3sqhgsbgtdggbcbphvhqpzh28
            pbkgmmgpm4seveneightwomqx
            szkqklg1xrmsfxbkfourhlntqsmkkmjtrbrtwo
            sevenphxrvpsp38two158
            64rtglqb67cnmdzrrvx5tqkvbgpqz
            3smjtffhhbthreefour225
            hcdjglmjdtzone7one92cmtmzp9
            jj3
            3dcbjfzxplnkhhc4
            nxjzbkseven5fivelsz1
            pbheightwo3
            five5bzsdmfive3two
            ninexbtdgdzbbjlgsc1three
            2eightslkrhgqfveightxjtvrkgh3
            234xgqhkkjxnlhggsix9dtlltxkfrthree
            zllsbdrrsix96xone5vhlrjcm
            433eight5fourvmn25
            oneseven4sevennine5vrbeight
            mss7tqqtq
            739
            neightwo1threesixsix
            eightfour3seven
            one16xfsqdptggonertjlljmdfive
            kccrvbgbhxbpeightnftvldlmthreeplxjsdvr8vgfttwonepm
            jxbkgpmgdgzjhxgjndtwoeightcgbcrpldzhfm5zjflmfsfs
            3ctzrzctj4eightfourfourqhhxtthxpx
            mjtsldxclctgonebhmeight2qgcskfhrxl
            59236
            cxqjgsrnndjxxjrghxqpnjrqtzct96knrtm4
            nftone8two2zh19
            9mczbptwosix
            zdbqvhnlp77zgzkxsnfzzjq8
            fivefournine7three
            4ltdk6mrpmchpzlq
            fivezxdmdqcctlpknlchdptnine9vd61
            pgdxcdtcrfmknpm9zddsxnncnjrrpj5qhvntbmb
            57867
            39kqfghxs
            fivesevenggdv47tstjpjl1
            5kvzngbgvmvtwo
            rnvpnkv2threeeighttwonssnzf
            ngqqbgtwoprqdnfmtntmbbrmgkrmgseven8
            9twoqczhkzcdeightwovv
            7vtjrdxfive
            hlkfp8four
            7mvhrltsixmfmfkxvpxc6twoseven
            2cpprnmhbsixzxb61
            qg8eightseven6vljxh3md
            one3poneone5lknlsix
            bjtwoseven9
            7fourglfpnlfbhndmgmnfdvzmgfjxrmzgsfcknzschlvjk
            lhqfzhdccrcscgqskbmskjxndffq8ninemdzk
            8glcmfjqnv5gdgccvqthdpzshsn
            two2five3two4qgf
            5nineseven
            12oneightt
            sixsevenninejjgkdmsnjgzfzxf46
            five63six31ppkvgdczbf3
            4sxxghjbmdcf8sgzsf4vfninethree
            cqmjgbkone6eightnn
            onesixonexdtsix8fourhdgbmzvp
            6l2fvjpbssvc
            xflcsglfjq93nhrrpl9eight
            bgthdvljfivecbxjn69
            twodmzspjstfccxq2twodzlfbsq
            669six
            nbhgctdtxcllvnmgnbvlgpzzq95six2xmbqfmlqq
            1hxr
            cvsxtkldqh1jpqnctrz
            595fourfive4four
            59threesevencmckfourfour
            oneseven78fivelplnpf4eighttwo
            flvqf9ssrgspj
            nined9pmdcfps5three
            fvxfrf9nineninesixtmkflzkcjfour7
            twongmgdlcxrnvcz8mnxvl4
            eightonekmzcspxone4
            chn2fxmpfourvds5rnphvp
            3eightsevenfbxzstbrpvvbfnhpdqzeightn
            9fourseven
            b35hh
            six7twotwomrgzltfxhzpbrbb
            eight2twojcbqvjbzb3
            sevenqtxlxshscrb7lhdcjkcnlkvghcgp
            three4n18six
            threezfqrhhhhklcxhcbdrone9
            2sevensnzthree2bktctgxm
            v66
            threetbkmd51sevennbrmnkflmkj4eight
            four5twockqqgrnine9dnvv6two
            rgvnfourkvcbconeninetdczskglone5
            82six3four55
            xjnjstvk66
            four72
            four9pdgs8twojjchqbqb36
            xgvljsgknqfvz2six2xmpvgxsjeight3
            vcrnl8fourtwo4five
            nine5gxdsrrxsqbsx77
            fourlgqzjnznnboneqr7m
            threekvdjs63lrfdvskhk7eight
            hqthneight3oneone
            gkfzr4vpfzqnveightqqvqpvvcxsx99
            gxhtwo17fourtjkgpbhxn3five
            dmcpvjfour4
            2fhgldxrhsdlgj
            threestseven33seven3six
            sixxlfhq2oneninenvjmp5
            five9eight9seven79
            threexpnbqninexmstddlcznine29
            two8ftmnhttjz
            ninevxeightxtm28five2
            bqkntmtgkpsgkfbtdkvtnq3seven87six
            14sixeight
            6foursixfive
            mpbqcseven8seven
            three6prbqk
            six6lkcjbnjvhfiveqppone95
            3thvllrn
            221threesix1two
            fdlzfivexhgbbkzsbkrjgshone13
            rhztctbf3mgbj
            1seven41oneeighttwo2mqt
            ct763
            nine9nine8hfgeight
            61threeseven79fkxrqqgcl
            fivesix8rgksjszlhcdqmxbhkxdvfour
            fiveg1
            2735sixninextzcxpftb
            kpnqg3four
            388zdxkjbqmrntrhtwovqjvdprtkpcdthtxx
            141qgkklqssnl1three
            6frqpmvkmhtxdhl1threethree9nine4
            sevenzxlszsk692one2
            onecjb3sixrqtkqmrjdseven8five
            oneqnffive7five2lvzthreemgtf
            44threethree
            hckkcxjzhrhc2eightdqrzbtx
            nineone2threesix8pdjbzxkrbsfour
            6two4kxntrqbhsqvtxdftqqkpfbsqhbssvjjqtnine
            1twoonennknzvgjj
            5fourdpzqdtsix81
            6brvvrgntseven
            vkghzgzzrhfivenine2qbxh
            foureight2qqdg7fourchbltsmxgnrtctpv
            twovbzzjzqxrnrmnqnsxrlckzb2
            zoneightfive8nine2one6
            dsrcd7sxteighthgqmkbzdflhbhrgsix
            7vfvzfgznfivemhhxkgxdrd83two
            48tflgpdszf
            kxrk5ntwoeighttwo
            twofivetwojxbtnfivethreeninesix9
            57fvgrcpm
            one1cxmqqfour77one6
            eightfive48
            sevenpvtclpklconedgnthreefive5
            8onesix6rvxd
            five35six294
            sksonenine3four
            eighttwo7fcpphztsnlqnf
            9eightseveneighteightmnjdscdbhm
            eight3six27vjnlvmlxrzzbsjvpvkkvb
            7zqcsgbmjch
            4nine2185
            9stxd5sevensix2qbnv2
            8xqhdkkmthreesevenpk7
            nine61one6ntgmgscglv
            three52cmppklbtfrpltp3
            48fivefivefivenfourthreeb
            jlchqchqseight1grbbhgp4rxjgxlx
            cklzfour44fivejqone9
            75q1
            ninejtwo5mfx6
            4mqvgrtsbfthreebffour9
            xtwone5knhdrrbv4six
            qthreethreegr9
            qknlgsvgntseven9
            ninezsrkx5
            7three8
            dseven7
            btbrjdmhzrvcx9threedmjflfbsvkvbl
            bgcfzgmrmgthreeeighttwohmzhsks89
            7tgfcvpjfour1four6twokglvsvgkk
            twoninekd5
            549seven
            one8drvtsevenknmdf9vpfggjsbbq
            nine27foursix5dqtmvntpnp5qfhhq
            seven92tlnkxssevenone
            three5dljshpbfiveqmzvcrkt
            4threesixeightfcvjl
            gfgsd46
            eight87eight318
            1tbbsmdhtwonedtt
            sixsixsix3tncpvghckn3
            onesix9threegtqgvfour5kjmlkkvgdp
            fourj4fbfjssf39sixninefive
            9eight6ltrnsr63dfjlhhmtsixtwo
            9twoxvcdpbtldsrfgtsix
            slzvnxrninesevenbfls1
            five4twotjfsfsv
            5one58plvtm
            6twopkkjkj68gmklcbqsixsevenseven
            five7one
            fourzxmhgf7tvqone8four
            7eightzzzphf
            xlgtkzljmbqxktwodhvdfsvnq43
            threetwofdgctgbhk5four52two
            3three7
            gjlppxbtnb42rlqhseven
            72blljfjds
            njvlxgphhkzoneg4sevengszqkr
            6kgplksixthree5tblnq
            rnrhsix7pfourfvslblz
            3mxztbfqpqh65eightnine2bbpeight
            sixonehgjfhqdqxc9fc
            96two
            8xvlnine7hrtnckxt
            7lzdqlrlrftzz
            knndninetdtlsdmmrthreefxph3
            6pflhvts32
            1rhjxvlxfdbhckhxtwo8
            seventjvtms36ninesfxnpfhxk
            rqftcbxkjbsbzhtxdt52
            8sfvvbtfjmv47seven5psseven
            kjeightwofive4onevlm9
            vtwonesnfshngpvfive4ttcqseven
            zpthreevf4gqcvrkdsnxthree5
            15sixlphbkgsqmpxbxjmg
            llhxfpmkhghfive7sixvbhhqg7
            nine2pdbgprkz
            qmdtwone66gcnlhtnjmfour
            9onetwoeighteight
            42five5sevenjjfbdtrdmb36
            tjj6cvhstnjfcklone
            vvgtpqlm6znvnlbd5nineninejjsphkzsix
            kconeight8xpgdhhrdtfzghrmthreefcb18six3
            six2one4vflp
            skqgc95two
            crzz84269sixfour
            five758jcjqdqcgqnqbqtvk8pjxmdb
            ninefn3jstbsbvfivefourthreeqs
            rrnfflfqnttgj9eighthnvmbfbtgnt
            bbtmcmlnn2sevensixxbgzbfthree
            8xzb9one3sfiveseven
            9nkhntmrll
            tpxrcthqbktwoeightonepcc4tzf26
            659nfbpb
            oneone2
            tmppzkhk49nine4
            8kgplfhvtvqpfsblddnineoneighthg
            332bfjbttrmbrxjqssr6oneeight
            threeeightfive6fxlckcsskpnd
            zeightvh9
            seventhree4seven
            bdmdqptkjzn74
            lsmcmgtflzxmszdkjmdsklrgvtcdlpx4
            xsftnb6mvgqxv17four
            7gqqvzkvzbvxghxonekqvsteight
            nineninekfp49
            """;
}