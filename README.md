se_repo (Software Engineering courses for students of IT dept. of College of Business and Law, Minsk 2018-2019)
========

## Tasks : https://docs.google.com/document/d/1mJ1_GH9hQGD0PgZe_tKVcbeBsWWtXbqu7j7Q4S-b_jk/edit?usp=sharing

## Git configuration.  
Configure ssh connection based on git documentation [https://help.github.com/articles/connecting-to-github-with-ssh](https://help.github.com/articles/connecting-to-github-with-ssh).

1). **Fork repository** `https://github.com/secourse2019/se-repo` to your own user.

2). **Clone your fork to your local machine**:

 `git clone git@github.com:your_fork_url/se-repo.git`

3). `git remote add origin <your_fork_url>`

4). `git checkout master`

5). `git remote add upstream git@github.com:secourse2019/se-repo.git`

6). `git pull upstream`

7). `git checkout -b work_local_branch upstream/master`

And then after adding files (`git add` ...) use `git commit` (add description) and then **push**:

    git push origin work_local_branch:work_remote_branch

And on [https://github.com/secourse2019/se-repo](https://github.com/secourse2019/se-repo) you will see possibility to "**Compare & Pull Request**"