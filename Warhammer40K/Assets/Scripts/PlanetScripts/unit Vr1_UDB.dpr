unit Vr1_UDB;
//
interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    pnlInstruct: TPanel;
    ledName: TLabeledEdit;
    ledID: TLabeledEdit;
    btnGenereer: TButton;
    redAfvoer: TRichEdit;
    procedure FormActivate(Sender: TObject);
    procedure btnGenereerClick(Sender: TObject);
  private
  sName, sID, sCode, sRandom : string;
  iPos : integer;
    { Private declarations }
  public
  function IsGeldig(IDnommer : string) : string; // Tests if ID is valid, If valid test if 7th charcater is 5[Male] or 0[Female]
  procedure Kode(Name : string); // Generate user kode as follows Example[ PJS235M ] First letter of name and surname plus a random 3 character number. plus Gender
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

{ TForm1 }

procedure TForm1.btnGenereerClick(Sender: TObject);
begin
  {
  redAfvoer.Lines.Add('Volle Name: ' + sName);
  redAfvoer.Lines.Add('ID-nommer: ' + sID);
  Kode(sName);
  redAfvoer.Lines.Add('Gebruikerskode: ' + sCode);
 }
if IsGeldig(sID) = 'Valid' then
begin
  redAfvoer.Lines.Add('Volle Name: ' + sName);
  redAfvoer.Lines.Add('ID-nommer: ' + sID);
  Kode(sName);
  redAfvoer.Lines.Add('Gebruikerskode: ' + sCode);
end
else
begin
  redAfvoer.Lines.Add('ID number INVALID');
end;

end;

{
check which planets are connected to itself
if that planet is connected to itself then dont connect to that planet
}

procedure TForm1.FormActivate(Sender: TObject);
begin
 sName := ledName.Text;
 sID := ledID.Text;
 sCode := '';
 sRandom := '';
end;

function TForm1.IsGeldig(IDnommer : string): string;
begin

if Length(sID) <> 13 then
begin
 Result := 'Invalid';
end
else
begin
if StrToInt(sID[7]) = 5 OR 0 then
begin
  Result := 'Valid';
end
else
begin
  Result := 'Invalid';
end;
end;

end;


procedure TForm1.Kode(Name: string);
var
 K : integer;
begin   // Example Petrus Jakobus Steyn and he is Male  Example[ PJS 235 M ]

 sRandom := IntToStr(Random(10)-1) + IntToStr(Random(10)-1) + IntToStr(Random(10)-1);
 sCode := sCode + sName[1]; // string =  Petrus Jakobus Steyn
                            //           123456789
 for K := 1 to Length(sName) do
 begin
  iPos := Pos(' ',sName);

   if iPos = 0 then
   begin
     sCode := sCode;
   end
   else
   begin
     sCode := sCode + sName[Ipos+1];
     Delete(sName,iPos,1);
   end;// end of if

 end;// end of for

 sCode := sCode + sRandom;

 if sID[7] = '0' then
 begin
 sCode := sCode + 'F';
 end;

  if sID[7] = '5' then
 begin
 sCode := sCode + 'M';
 end;

end;

end.