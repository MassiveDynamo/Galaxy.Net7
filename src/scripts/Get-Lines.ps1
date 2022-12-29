$file = 'D:\data\EDSM-Dumps\systemsWithCoordinates.json'
[System.IO.StreamReader]$sr = [System.IO.File]::Open($file, [System.IO.FileMode]::Open, [System.IO.FileShare]::Read )
$lineCount = 0
$currentMaxName = ""

while (-not $sr.EndOfStream) {
    $line = $sr.ReadLine()
    if ( $line.Trim().Length -lt 20 ) { continue }
    if ( $line.EndsWith(',')) {
        $line = $line.Substring(0, $line.Length - 1)
    }

    $system = $line | ConvertFrom-Json -AsHashtable
    if( $system.name.Length -gt $currentMaxName.Length ) {
        $currentMaxName = $system.name
        Write-Host "New max name: $currentMaxName. $($currentMaxName.Length)"
    } 
    
    $lineCount++
    if( $lineCount % 1000000 -eq 0) {
        Write-Host "Linecount: $lineCount"
    }
}

$sr.Close()
Write-Host "Linecount: $lineCount"
Write-Host "Max name: $currentMaxName. $($currentMaxName.Length)"