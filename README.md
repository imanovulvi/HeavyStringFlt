# HeavyStringFlt
Bu WebAPI Core layıhısi böyük həcmli mətnləri  arxa planda Jaro-Winkler algoritmasını istifada ederək filtirasiya aparır.

# Düsturlar 
## Jaro 
1/3 * ( (matches / |s1|) + (matches / |s2|) + ((matches - transpositions) / matches) )
## Jaro+Winkler 
Jaro(s1, s2) + (prefixLength * 0.1 * (1 - Jaro(s1, s2))) 
