# Generated by jeweler
# DO NOT EDIT THIS FILE DIRECTLY
# Instead, edit Jeweler::Tasks in Rakefile, and run 'rake gemspec'
# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "pngsteg"
  s.version = "0.0.0"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Andrey \"Zed\" Zaikin"]
  s.date = "2013-01-06"
  s.email = "zed.0xff@gmail.com"
  s.executables = ["pngsteg"]
  s.files = [
    "Gemfile",
    "Gemfile.lock",
    "Rakefile",
    "VERSION",
    "bin/pngsteg",
    "lib/pngsteg.rb",
    "lib/pngsteg/checker.rb",
    "lib/pngsteg/cli.rb",
    "lib/pngsteg/extractor.rb",
    "samples/flower.png",
    "samples/flower_rgb1.png",
    "samples/flower_rgb2.png",
    "samples/flower_rgb3.png",
    "samples/flower_rgb4.png",
    "samples/flower_rgb5.png",
    "samples/flower_rgb6.png",
    "spec/samples_spec.rb",
    "spec/spec_helper.rb"
  ]
  s.homepage = "http://github.com/zed-0xff/pngsteg"
  s.licenses = ["MIT"]
  s.require_paths = ["lib"]
  s.rubygems_version = "1.8.24"
  s.summary = "Detect stegano-hidden data in PNG files"

  if s.respond_to? :specification_version then
    s.specification_version = 3

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
      s.add_runtime_dependency(%q<zpng>, [">= 0.2.1"])
      s.add_development_dependency(%q<rspec>, [">= 2.8.0"])
      s.add_development_dependency(%q<bundler>, [">= 1.0.0"])
      s.add_development_dependency(%q<jeweler>, ["~> 1.8.4"])
      s.add_development_dependency(%q<awesome_print>, [">= 0"])
    else
      s.add_dependency(%q<zpng>, [">= 0.2.1"])
      s.add_dependency(%q<rspec>, [">= 2.8.0"])
      s.add_dependency(%q<bundler>, [">= 1.0.0"])
      s.add_dependency(%q<jeweler>, ["~> 1.8.4"])
      s.add_dependency(%q<awesome_print>, [">= 0"])
    end
  else
    s.add_dependency(%q<zpng>, [">= 0.2.1"])
    s.add_dependency(%q<rspec>, [">= 2.8.0"])
    s.add_dependency(%q<bundler>, [">= 1.0.0"])
    s.add_dependency(%q<jeweler>, ["~> 1.8.4"])
    s.add_dependency(%q<awesome_print>, [">= 0"])
  end
end
