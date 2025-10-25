PS C:\Users\kagan\Projects\BtkAkademi> cd "C:\Users\kagan\Projects\BtkAkademi"
>> 
PS C:\Users\kagan\Projects\BtkAkademi> git status
>> 
On branch main
nothing to commit, working tree clean
PS C:\Users\kagan\Projects\BtkAkademi> git init
>> 
Reinitialized existing Git repository in C:/Users/kagan/Projects/BtkAkademi/.git/
PS C:\Users\kagan\Projects\BtkAkademi> git remote -v
>> 
origin  https://github.com/kaganaydogan/BtkAkademi.git (fetch)
origin  https://github.com/kaganaydogan/BtkAkademi.git (push)
PS C:\Users\kagan\Projects\BtkAkademi> git remote remove origin
>> git remote add origin https://github.com/kaganay/BtkAkademi.git
>> 
PS C:\Users\kagan\Projects\BtkAkademi> git init     
Reinitialized existing Git repository in C:/Users/kagan/Projects/BtkAkademi/.git/
PS C:\Users\kagan\Projects\BtkAkademi> git remote
origin
PS C:\Users\kagan\Projects\BtkAkademi> git remote -v
origin  https://github.com/kaganay/BtkAkademi.git (fetch)
origin  https://github.com/kaganay/BtkAkademi.git (push)
PS C:\Users\kagan\Projects\BtkAkademi> git add .
>> git commit -m "First upload to GitHub - BtkAkademi MVC Project"
>> git branch -M main
>> git push -u origin main
>>
On branch main
nothing to commit, working tree clean
Enumerating objects: 117, done.
Counting objects: 100% (117/117), done.
Delta compression using up to 20 threads
Compressing objects: 100% (111/111), done.
Writing objects: 100% (117/117), 963.16 KiB | 3.92 MiB/s, done.
Total 117 (delta 30), reused 0 (delta 0), pack-reused 0 (from 0)
remote: Resolving deltas: 100% (30/30), done.
To https://github.com/kaganay/BtkAkademi.git
 * [new branch]      main -> main
branch 'main' set up to track 'origin/main'.
PS C:\Users\kagan\Projects\BtkAkademi> 